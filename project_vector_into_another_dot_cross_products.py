################################################################################
#
# Copyright (c) 2022
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
# Project vector into anther - dot and cross vector products recap
#
################################################################################

import numpy as np
import matplotlib.pyplot as plt

a = np.array([10,  3])  # vector a
b = np.array([2, -4])  # vector a

# project a vector into b vector
dot = float(np.dot(a, b))  # |A| |B| cos(theta) = a1b1 + a2b2
norm_square_B = float(np.dot(b, b))  # |B|^2 because we didn't take sqrt
proj = b * (dot/norm_square_B)  # projection formula simply scaling b vector by: |A|cos(theta) / |B|

# rotate b by 90 degrees clockwise
b_rotated = [b[1], -b[0]]

# cross product (gives a vector, but if 2D vectors provided numpy gives a scalar; can be used to check if a point is left or right to a line)
cross = np.cross(a, b)  # |A| |B| cos(theta) * n vector perpendicular to their plane = (...)i+(...)j+(...)k
print(cross)  # gives 10*-4-3*2 k = -46k (negative if from a head to b head is clockwise)

# dot product of 2D vectors in numpy does matmul or @ in python

# plot results
ax = plt.axes()
ax.arrow(0, 0, *a, head_width=0.5, head_length=0.5, color='g')
ax.arrow(0, 0, *b, head_width=0.5, head_length=0.5, color='b')
ax.arrow(0, 0, *proj, head_width=0.5, head_length=0.5, color='r')
ax.arrow(0, 0, *b_rotated, head_width=0.5, head_length=0.5, color='k')
plt.xlim(-7, 12)
plt.ylim(-7, 5)
ax.set_aspect(1)
plt.show()
