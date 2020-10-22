import matplotlib.pyplot as plt
from scipy.optimize import leastsq
import numpy as np

x = [-5, 0, 5, 0]
y = [0, 5, 0, -6]

plt.plot(x, y, '*')

def losses(c): # Returns array: loss for each point
  dist = np.sqrt((x-c[0])**2 + (y-c[1])**2) # Array
  return dist - np.mean(dist)

centre_intial = np.mean(x), np.mean(y)
centre, _ = leastsq(losses, centre_intial) # Losses to minize their squres error
r = np.sqrt((x-centre[0])**2 + (y-centre[1])**2).mean()

plt.gcf().gca().add_artist(plt.Circle(centre, r))
