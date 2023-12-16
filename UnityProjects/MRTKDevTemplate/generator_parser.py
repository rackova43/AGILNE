import igraph as ig
import matplotlib.pyplot as plt
import json

##### GRAF #####
g = ig.Graph.Erdos_Renyi(n=50, p=0.6)

##### VYBER LAYOUTU #####
layout = g.layout('fruchterman_reingold_3d')


##### VYKRESLENIE #####
# fig = plt.figure()
# ax = fig.add_subplot(111, projection='3d')

# x = [pos[0] for pos in layout.coords]
# y = [pos[1] for pos in layout.coords]
# z = [pos[2] for pos in layout.coords]

# ax.scatter(x, y, z)

# for edge in g.es:
#     start, end = edge.tuple
#     x_values = [layout.coords[start][0], layout.coords[end][0]]
#     y_values = [layout.coords[start][1], layout.coords[end][1]]
#     z_values = [layout.coords[start][2], layout.coords[end][2]]
#     ax.plot(x_values, y_values, z_values, color='b')

# ax.set_xlabel('X axis')
# ax.set_ylabel('Y axis')
# ax.set_zlabel('Z axis')

# plt.show()

positions = layout.coords

nodes_data = [{'id': i, 'position': pos} for i, pos in enumerate(positions)]
edges_data = [{'source': edge.source, 'target': edge.target} for edge in g.es]

graph_data = {'nodes': nodes_data, 'edges': edges_data}
with open('graph_data.json', 'w') as f:
    json.dump(graph_data, f, indent=4)


