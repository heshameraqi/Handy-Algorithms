################################################################################
#
# Copyright (c) 2021
# Authors:
#  Hesham M. Eraqi (heraqi@aucegypt.edu)
#
################################################################################

# Sparse Matrix Array Represntation
class SparseMatrix:
    def __init__(self, *args):
        if len(args) == 1:  # Because we can't define multiple constructors
            sparse_matrix = args[0]
            self.rows = len(sparse_matrix)
            self.cols = len(sparse_matrix[0])
            # Storing into compact format: row, column, value for every non-zero element
            self.compact_matrix = []
            for i in range(self.rows):
                for j in range(self.cols):
                    if sparse_matrix[i][j] != 0:
                        self.compact_matrix.append([i, j, sparse_matrix[i][j]])
        else:
            self.compact_matrix = args[0]
            self.rows = args[1]
            self.cols = args[2]

    def transpose(self):
        compact_matrix_1_trans = SparseMatrix(self.compact_matrix.copy(), self.rows, self.cols)
        compact_matrix_1_trans.compact_matrix = [[num[1], num[0], num[2]] for num in
                                                 compact_matrix_1_trans.compact_matrix]
        compact_matrix_1_trans.compact_matrix.sort(key=lambda x: x[0])  # to  preserve the sorting by row-col value
        return compact_matrix_1_trans

    def add(self, b_matrix):
        if self.rows != b_matrix.rows or self.cols != b_matrix.cols:
            return None
        else:
            result = SparseMatrix([], self.rows, self.cols)
            a_pos = 0
            b_pos = 0
            while (a_pos < len(self.compact_matrix) and b_pos < len(b_matrix.compact_matrix)):
                # items are in the same row & col
                if self.compact_matrix[a_pos][0] == b_matrix.compact_matrix[b_pos][0] and self.compact_matrix[a_pos][
                    1] == b_matrix.compact_matrix[b_pos][1]:
                    result.compact_matrix.append(b_matrix.compact_matrix[b_pos])
                    result.compact_matrix[-1][2] += self.compact_matrix[a_pos][2]
                    a_pos += 1
                    b_pos += 1
                # a item is before
                elif (self.compact_matrix[a_pos][0] < b_matrix.compact_matrix[b_pos][0]) or (
                        self.compact_matrix[a_pos][0] == b_matrix.compact_matrix[b_pos][0] and
                        self.compact_matrix[a_pos][1] < b_matrix.compact_matrix[b_pos][1]):
                    result.compact_matrix.append(self.compact_matrix[a_pos])
                    a_pos += 1
                # a item is before
                else:
                    result.compact_matrix.append(b_matrix.compact_matrix[b_pos])
                    b_pos += 1
            # Add remaining items in a or b compact_matrix
            while (a_pos < len(self.compact_matrix)):
                result.compact_matrix.append(self.compact_matrix[a_pos])
                a_pos += 1
            while (b_pos < len(b_matrix.compact_matrix)):
                result.compact_matrix.append(b_matrix.compact_matrix[b_pos])
                b_pos += 1

            return result

    # TODO: Fix this function
    def multiply(self, b_matrix):
        if self.cols != b_matrix.rows:
            return None
        else:
            a_pos = 0
            b_pos = 0
            result = SparseMatrix([], self.rows, b_matrix.cols)
            b_trans = b_matrix.transpose()  # transpose b to compare row and col values and to add them at the end

            # For every row in A
            while a_pos < len(self.compact_matrix):
                r = self.compact_matrix[a_pos][0]  # current row in result matrix
                # For every column in B
                b_pos = 0
                while b_pos < len(b_trans.compact_matrix):
                    c = b_trans.compact_matrix[b_pos][0]  # current column in result matrix

                    # fill that row and column value
                    temp_a = a_pos
                    temp_b = b_pos
                    sum = 0
                    while (temp_a < len(self.compact_matrix) and self.compact_matrix[temp_a][0] == r and
                           temp_b < len(b_trans.compact_matrix) and b_trans.compact_matrix[temp_b][0] == c):
                        if self.compact_matrix[temp_a][1] < b_trans.compact_matrix[temp_b][1]:  # skip a
                            temp_a += 1
                        elif self.compact_matrix[temp_a][1] > b_trans.compact_matrix[temp_b][1]:  # skip b
                            temp_b += 1
                        else:  # same col, so multiply and increment
                            sum += self.compact_matrix[temp_a][2] * b_trans.compact_matrix[temp_b][2]
                            temp_a += 1
                            temp_b += 1
                    if sum != 0:
                        result.compact_matrix.append([r, c, sum])

                    # jump to next column
                    while b_pos < len(b_trans.compact_matrix) and b_trans.compact_matrix[b_pos][0] == c:
                        b_pos += 1

                # jump to next row
                while a_pos < len(self.compact_matrix) and self.compact_matrix[a_pos][0] == r:
                    a_pos += 1
            return result


# Storing in Array represntatuin
compact_matrix_0 = SparseMatrix([[0, 0, 3, 0, 4],
                                 [0, 0, 5, 7, 0],
                                 [0, 0, 0, 0, 0],
                                 [0, 2, 6, 0, 0]])
print(compact_matrix_0.compact_matrix)

compact_matrix_1 = SparseMatrix([[1, 2, 10],
                                 [1, 4, 12],
                                 [3, 3, 5],
                                 [4, 1, 15],
                                 [4, 2, 12]], 4, 4)
compact_matrix_2 = SparseMatrix([[1, 3, 8],
                                 [2, 4, 23],
                                 [3, 3, 9],
                                 [4, 1, 20],
                                 [4, 2, 25]], 4, 4)

print(compact_matrix_1.transpose().compact_matrix)
print(compact_matrix_1.add(compact_matrix_2).compact_matrix)
print(compact_matrix_1.multiply(compact_matrix_2).compact_matrix)
