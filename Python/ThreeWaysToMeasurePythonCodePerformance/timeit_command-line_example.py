import timeit


def test_fn():
    for i in range(10):
        print(i)

timeit.timeit(lambda: test_fn(), number=10000)