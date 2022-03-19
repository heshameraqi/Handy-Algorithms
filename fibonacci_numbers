################################################################################
#
# Copyright (c) 2022
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################
# O(2^n) since every node will split into two subbranches
def fib_recursive(n):
    if n == 0:
        return 0
    elif n == 1:
        return 1
    else:
        return fib_recursive(n-1)+fib_recursive(n-2)

# Time complexity: O(n), space complexity: O(1)
def fib_db(n):
    f_n_2 = 0 #F(n-2)
    f_n_1 = 1 #F(n-1)
    f_n = 0
    if n == 0:
        return f_n_2
    if n == 1:
        return f_n_1

    for i in range(2, n+1):
        f_n = f_n_1 + f_n_2
        f_n_2 = f_n_1
        f_n_1 = f_n
    
    return f_n


print(fib_recursive(2)) # Output : 1
print(fib_recursive(9)) # Output : 34

print(fib_db(2)) # Output : 1
print(fib_db(9)) # Output : 34
