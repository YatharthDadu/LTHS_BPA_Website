def is_magic_square(square):
    n = len(square)
    magic_sum = n * (n**2 + 1) // 2
    # Check rows
    for row in square:
        if sum(row) != magic_sum:
            return (False, "Row sum incorrect")
    # Check columns
    for j in range(n):
        if sum(square[i][j] for i in range(n)) != magic_sum:
            return (False, "Column sum incorrect")
    # Check diagonals
    if sum(square[i][i] for i in range(n)) != magic_sum:
        return (False, "Main diagonal sum incorrect")
    if sum(square[i][n-i-1] for i in range(n)) != magic_sum:
        return (False, "Anti-diagonal sum incorrect")
    # Check that all numbers from 1 to n**2 are used exactly once
    used_numbers = set()
    for row in square:
        for x in row:
            if x in used_numbers or x < 1 or x > n**2:
                return (False, "Invalid or duplicate number")
            used_numbers.add(x)
    return (True, "")

with open("magic.txt", "r") as input_file, open("results.txt", "w") as output_file:
    while True:
        # Read N
        line = input_file.readline().strip()
        if not line:
            break
        n = int(line)
        # Read the square
        square = []
        for i in range(n):
            row = list(map(int, input_file.readline().strip().split()))
            square.append(row)
        # Evaluate the square
        result, reason = is_magic_square(square)
        # Write the result to the output file
        for row in square:
            output_file.write(" ".join(str(x) for x in row) + "\n")
        if result:
            output_file.write("MAGIC\n\n")
        else:
            output_file.write("NOT MAGIC: " + reason + "\n\n")
