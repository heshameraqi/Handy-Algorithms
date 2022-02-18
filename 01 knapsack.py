################################################################################
#
# Copyright (c) 2020
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################
import numpy as np

def knap_sack(W, wt, val):
    V = np.zeros((len(wt)+1, W+1))
   
    for r in range(1, V.shape[0]):
        for c in range(1, V.shape[1]):
            V[r,c] = V[r-1,c] # Won't take it
            if wt[r-1] <= c: # For indexing
                V[r,c] = max(V[r-1,c], V[r-1,c-wt[r-1]]+val[r-1]) # Leave it OR add it to the wight before adding it?
     
    print (V)
    return V[-1][-1]

val = [6, 10, 12] 
wt = [1, 2, 3] 
W = 5
print(knap_sack(W, wt, val)) # 22
