import numpy as np
import random

import func
import plot_func as pf

sizes = [10]
types = ["random", "best", "worst"]
data_plot = {'random': {'bubble':{}, 'insertion':{}, 'bubble_impr':{}, 'self_insertion':{}},
             'best':   {'bubble':{}, 'insertion':{}, 'bubble_impr':{}, 'self_insertion':{}},
             'worst':  {'bubble':{}, 'insertion':{}, 'bubble_impr':{}, 'self_insertion':{}}}

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

        data_self_insertion = np.copy(data)
        self_insertion_op_count = func.self_insertion_sort(data_self_insertion)
        print("\tSelf insertion sort operation count:", int(self_insertion_op_count))
        data_plot[gen_type]['self_insertion'][n] = self_insertion_op_count

pf.plot_data(data_plot, logarithmic=True, oneplot=False)
