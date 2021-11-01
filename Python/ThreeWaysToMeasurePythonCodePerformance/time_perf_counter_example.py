import time


start_time = time.perf_counter()

for i in range(10):
    print(i)

end_time = time.perf_counter()
execution_time = end_time - start_time
print(f"The execution time is: {execution_time}")