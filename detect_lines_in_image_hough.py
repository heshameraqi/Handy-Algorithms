################################################################################
#
# Copyright (c) 2020
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################

# Create an edge image from 0 to 1
import matplotlib.pyplot as plt
import numpy as np

from PIL import Image, ImageDraw
polygon_coord = [(10,20), (40,40), (60,60), (60,10),(80,80)]
img = Image.new('L', (100, 100), 0)
ImageDraw.Draw(img).polygon(polygon_coord, outline=1, fill=0)
img = np.array(img)

plt.imshow(img)

# Create Hough Space
import math
r_values= 200
theta_values = 300
hough_matrix = np.zeros((r_values, theta_values))
for x in range(img.shape[0]):
    for y in range(img.shape[1]):
        if img[x,y] == 1: continue
        for th in range(theta_values):
            theta = th * math.pi / theta_values
            r = int(x * math.cos(theta) + y * math.sin(theta))
            hough_matrix[r,th] = hough_matrix[r,th] + 1
plt.figure()
plt.imshow(hough_matrix)

# Find the maximum and plot it
max_id = np.where(hough_matrix==hough_matrix.max())
theta = max_id[1] * math.pi / theta_values
r = max_id[0]

plt.figure()
plt.imshow(img)
x = list(range(img.shape[0]))
y = []
for i in x:
   y.append( (r - i*math.cos(theta)) / math.sin(theta) )
plt.plot(x, y, linewidth=10)
