from scipy.optimize import leastsq
import numpy as np

x = [-5, 0, 5, 0]
y = [0, 5, 0, -6]

def losses(c):  # Returns array: loss for each point
  dist = np.sqrt((x-c[0])**2 + (y-c[1])**2)  # Array
  r = np.mean(dist)
  return dist - r  # can't take the mean of this because scipy,optimize.leastsq needs it longer than the number of parameters to optimize (2 in our case)

# For any centre, we can calculate the best r (the mean of distances from that centre)
centre_intial = np.mean(x), np.mean(y)
centre_optimized, _ = leastsq(losses, centre_intial)  # Losses to minimize their squares error
r = np.sqrt((x-centre_optimized[0])**2 + (y-centre_optimized[1])**2).mean()

# Plot
import matplotlib.pyplot as plt
plt.plot(x, y, 'r*')
plt.gcf().gca().add_artist(plt.Circle(centre_optimized, r))
plt.show()
