# Create an edge image from 0 to 1
import matplotlib.pyplot as plt
import numpy as np
import math  # for pi, cos, and sin

# Draw an Image with a polygon
from PIL import Image, ImageDraw
polygon_coord = [(10,20), (40,40), (60,60), (60,10), (80,80)]
img = Image.new('L', (100, 100), 0)
ImageDraw.Draw(img).polygon(polygon_coord, outline=1)
img = np.array(img)

# Create Hough Space (line equation in polar coordinates is ρ=xcosθ+ysinθ)
theta_values = 300  # theta from 0 to pi
r_values = 300  # rho from 0 to image diagonal
img_diag = math.sqrt(100**2+100**2)
hough_matrix = np.zeros((r_values, theta_values))
for x in range(img.shape[1]):
    for y in range(img.shape[0]):
        if img[x, y] == 1:  # If pixel is 1, try all possible lines passing by it (try different thetas)
            for theta_idx in range(theta_values):  # for each theta tried, there is rho value
                theta = theta_idx * math.pi / theta_values
                r = int(x * math.cos(theta) + y * math.sin(theta))
                r_idx = int(r * r_values / img_diag)
                hough_matrix[r_idx, theta_idx] += 1

# Find the maximum and plot it
plt.imshow(img)
plt.figure()
plt.imshow(hough_matrix)
plt.figure()
plt.imshow(img)
for i in range(5):
    max_id = np.where(hough_matrix == hough_matrix.max())
    if len(max_id[0]) > 1:  # if multiple maxima
        max_id = [max_id[0][0], max_id[1][0]]
    theta = max_id[1] * math.pi / theta_values
    r = max_id[0] * img_diag / r_values
    # Remove the selected maximum so next loop visualize the next one
    hough_matrix[max_id[0], max_id[1]] = 0
    max_id = np.where(hough_matrix == hough_matrix.max())

    # Plot the line
    x = list(range(img.shape[1]))
    y = []
    for i in x:
       y.append( (r - i*math.cos(theta)) / math.sin(theta))
    plt.plot(y, x, linewidth=2)
plt.show()
