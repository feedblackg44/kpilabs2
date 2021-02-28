import numpy as np
import random

import func
import plot_func as pf

sizes = [10, 100, 1000, 10000]
types = ["random", "best", "worst"]
data_plot = {'random': {'bubble':{}, 'insertion':{}, 'bubble_impr':{}}, 
             'best':   {'bubble':{}, 'insertion':{}, 'bubble_impr':{}},
             'worst':  {'bubble':{}, 'insertion':{}, 'bubble_impr':{}}}

for n in sizes:
    print("\nDATA SIZE: ", n)
    for gen_type in types:
        print("\n\tDATA TYPE:", gen_type)
        data = func.generate_data(n, gen_type)

        data_bubble = np.copy(data)
        bubble_op_count = func.bubble_sort(data_bubble)
        print ("\tBubble sort operation count:", int(bubble_op_count))
        data_plot[gen_type]['bubble'][n] = bubble_op_count

        data_bubble_impr = np.copy(data)
        bubble_impr_op_count = func.bubble_impr_sort(data_bubble_impr)
        print("\tImproved bubble sort operation count:", int(bubble_impr_op_count))
        data_plot[gen_type]['bubble_impr'][n] = bubble_impr_op_count

        data_insertion = np.copy(data)
        insertion_op_count = func.insertion_sort(data_insertion)
        print("\tInsertion sort operation count:", int(insertion_op_count))
        data_plot[gen_type]['insertion'][n] = insertion_op_count

pf.plot_data(data_plot, logarithmic=True, oneplot=False)
