################################################################################
#
# Copyright (c) 2020
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################
sparseMatrix = [[0,0,3,0,4],[0,0,5,7,0],[0,0,0,0,0],[0,2,6,0,0]] 
  
# initialize size as 0 
size = 0
  
for i in range(4): 
    for j in range(5): 
        if (sparseMatrix[i][j] != 0): 
            size += 1
  
compactMatrix = [[0 for i in range(size)] for j in range(3)] 
  
k = 0
for i in range(4): 
    for j in range(5): 
        if (sparseMatrix[i][j] != 0): 
            compactMatrix[0][k] = i 
            compactMatrix[1][k] = j 
            compactMatrix[2][k] = sparseMatrix[i][j] 
            k += 1
