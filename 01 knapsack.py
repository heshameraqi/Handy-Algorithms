################################################################################
#
# Copyright (c) 2022
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################
import numpy as np

def knap_sack(W, wt, val):
    v_mat = np.zeros((W+1, len(wt)+1))

    for r in range(1, v_mat.shape[0]):
        for c in range(1, v_mat.shape[1]):
            v_mat[r,c] = v_mat[r, c-1] # Won't take it
            if r-wt[c-1] >= 0: # For indexing protection
                v_take = v_mat[r-wt[c-1], c-1] + val[c-1] # Value if we take it
                if v_take > v_mat[r,c]: 
                    v_mat[r,c] = v_take

    print(v_mat)
    return v_mat[-1,-1]


val = [6, 10, 12] 
wt = [1, 2, 3] 
W = 5
print(knap_sack(W, wt, val)) # 22
