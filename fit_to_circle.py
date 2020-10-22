# Least_Squares_Circle using least squares fitting (scipy.optimize.leastsq)
import numpy as np
from scipy import optimize
import math
import matplotlib.pyplot as plt

# The points
x = np.array([  9, 35, -13,  10,  23,   0])
y = np.array([ 34, 10,   6, -14,  27, -10])
plt.plot(x, y, 'r*')

def dist_to_centre(c):
    r = np.sqrt((x-c[0])**2 + (y-c[1])**2) # array
    return r - r.mean() # error to minimize

center_intial = np.mean(x), np.mean(y)
center, _ = optimize.leastsq(dist_to_centre, center_intial)  # Get best centre with smallest dist_to_centre
r = np.sqrt((x-center[0])**2 + (y-center[1])**2).mean()
plt.gcf().gca().add_artist(plt.Circle(center, r, color='r'))
