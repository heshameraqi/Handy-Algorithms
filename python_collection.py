################################################################################
#
# Copyright (c) 2020
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################

# Point is to the left of the line
# if ( (y[e]−y[s])/(x[e]−x[s]) <= (y[m]−y[s])/(x[m]−x[s]) ):

# To check if 2 line segments intersect:
# if from one line, the other line two points are left and right to it

# Get intersection point:
# There is a formula for that to use

# String useful operations:
#s = "Hesham Eraqi"
#print(s[1:5]) # From index 1 to 4
#print(s[1:5:2]) # Stride of 2
#print(s[1:5:-1]) # Stride of -1 means flip
#print(s.replace('H', 'h'))
#print(s.split())

# Sets
#x1 = ["Hesham", "Eraqi", "Hesham", "Asmaa"]
#x2 = ["Mohammed", "Haidy", "Eraqi", "Hesham"]
#print(set(x1)) # unique elements
#print(sorted(set(x1))) 
#print( set(x1) & set(x2) ) # sets intersection
#print( set(x1) ^ set(x2) ) # sets unique elements

# Matrix Multplication
A = [[12,7,3],
    [4 ,5,6],
    [7 ,8,9]]
B = [[5,8,1,2],
    [6,7,3,0],
    [4,5,9,1]]
# Result matrix
# C = [[0]*len(B[0])]*len(A) # Mistake: rows will be the same refernce
C = [ [0]*len(B[0]) for _ in range(len(A)) ]
for i in range(len(A)): # rows in A
    for j in range(len(B[0])): # columns in B
        row = A[i]
        col = [x[j] for x in B]
        C[i][j] = sum ( [row[i]*col[i] for i in range(len(row))] )
print(C)

# Matrix Transpose
A = [[1,2],
     [3,4],
     [5,6]]
Trans = [ [A[i][j] for i in range(len(A))] for j in range(len(A[0])) ] # i is for rows, j is for columns, the inner loop is giving list of rows
print(Trans)
