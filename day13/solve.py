pairs = []
indicies_of_right_ordered_pairs = []


def indent(depth):
    return " " * depth * 2

def list_values(l):
    l = l[1:-1]
    v = []

    acc=""
    i = 0
    braces = 0

    while i < len(l):
        char = l[i]
        if char == "[":
            braces+=1
            acc += char
        elif char == "]":
            braces-=1
            acc += char
        elif char == ",":
            if braces > 0:
                acc += char
            elif braces == 0:
                v.append(acc)
                acc = ""
        else:
             acc += char

        i+=1

    if acc != "": v.append(acc)
    return v

# Compare two packets given the rules outlined
# in the problem description
#
# Returns
#  negative value if left < right
#   0 if left == right
#   positive value if left > right
def comp(left, right, depth):
    print(f"{indent(depth)}- Compare {left} vs {right}")

    if is_integer(left) and is_list(right):
        left = integer_to_list(left)
        print(f"- Mixed types; convert left to {left} and retry comparison")
        return comp(left, right, depth)
    elif is_list(left) and is_integer(right):
        right = integer_to_list(right)
        return comp(left, right, depth)
    elif is_integer(left) and is_integer(right):
        return int(left) - int(right)
    elif is_list(left) and is_list(right):
        left_values = list_values(left)
        right_values = list_values(right)

        if len(left_values) == 0 and len(right_values) > 0:
            return -1

        if len(left_values) == 0 and len(right_values) == 0:
            return 0

        i = 0
        while i < len(left_values):
            if i+1 > len(right_values):
                return -1

            left_value = left_values[i]
            right_value = right_values[i]

            result = comp(left_value, right_value, depth+1)
            
            if result < 0:
                return result
            elif result > 0:
                return result   

            i += 1  

    return 0

# Decides if a value is a list
# 
# Returns
#  True if v is a list
#  False if v is not a list
def is_list(v):
    if len(v) > 0 and v[0] == "[": return True
    else: return False

# Decides if a value is an integer
#
# Returns
#  True if v is and integer
#  False if v is not an integer
def is_integer(v):
    
    return not is_list(v) and len(v) > 0

def integer_to_list(v):
    return f"[{v}]"


with open('input.txt', 'r') as f:
    while True:
        left = f.readline()
        if left == "": break

        right = f.readline()
        _ = f.readline() # throw away blank line between groups

        pair = (left.strip(), right.strip())
        pairs.append(pair)


for pair_num, pair in enumerate(pairs):
    print(f"== Pair {pair_num+1} ==")
    result = comp(pair[0], pair[1], 0)

    if result <= 0:
        print("Right!")
        indicies_of_right_ordered_pairs.append(pair_num + 1)
    else:
        print("wrong")


print(f"Correct pair numbers: {indicies_of_right_ordered_pairs}")
print(f"Sum: {sum(indicies_of_right_ordered_pairs)}")
