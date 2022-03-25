# A* is just like Dijkstra, the only difference is that A* tries to look for a better path by using a heuristic function which gives 
#  priority to nodes that are supposed to be better than others while Dijkstra's just explore all possible paths.
# Dijkstra is a special case for A* (when the heuristics is zero).
# The heuristic function should be admissible (so A* provides optimal solution): never overestimate the cost. That means, the real cost to reach 
#  goal node from node n should be greater than or equal h(n).

import sys
 
class Graph():
    def __init__(self, vertices):
        self.V = vertices
        self.graph = [[0 for column in range(vertices)] for row in range(vertices)]
 
    def printSolution(self, dist):
        print("Vertex \tDistance from Source")
        for node in range(self.V):
            print(node, "\t", dist[node])
 
    def minDistance(self, dist, vertDone):
        min = sys.maxsize
        for u in range(self.V):
            if dist[u] < min and vertDone[u] == False:
                min = dist[u]
                min_index = u
        return min_index
 
    # O(V^2), but we can achive O(E log V) using binary heap if the input graph is represented using adjacency list
    def dijkstra(self, src):
        dist = [sys.maxsize] * self.V
        dist[src] = 0
        vertDone = [False] * self.V  # vertices whose minimum distance from the source is calculated and finalized
 
        for _ in range(self.V): # For every vertix: X
            x = self.minDistance(dist, vertDone) # get min distance
            vertDone[x] = True

            # select the vertix that is neughbour to it with minimum distance value and is not done: Y
            for y in range(self.V):
                if self.graph[x][y] > 0 and vertDone[y] == False and dist[y] > dist[x] + self.graph[x][y]:
                    # Update distance of Y if from X, it's shorter to reach it
                    dist[y] = dist[x] + self.graph[x][y]
 
        self.printSolution(dist)
 
# Driver program
g = Graph(9)
g.graph = [[0, 4, 0, 0, 0, 0, 0, 8, 0],
        [4, 0, 8, 0, 0, 0, 0, 11, 0],
        [0, 8, 0, 7, 0, 4, 0, 0, 2],
        [0, 0, 7, 0, 9, 14, 0, 0, 0],
        [0, 0, 0, 9, 0, 10, 0, 0, 0],
        [0, 0, 4, 14, 10, 0, 2, 0, 0],
        [0, 0, 0, 0, 0, 2, 0, 1, 6],
        [8, 11, 0, 0, 0, 0, 1, 0, 7],
        [0, 0, 2, 0, 0, 0, 6, 7, 0]
        ]
g.dijkstra(0) # Source is vertix 0
