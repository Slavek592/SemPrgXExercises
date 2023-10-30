alphabet = {"e": 1, "a": 1, "i": 1, "o": 1, "n": 1, "r": 1,
 "t": 1, "l": 1, "s": 1, "u": 1, "d": 2, "g": 2, "b": 3,
 "c": 3, "m": 3, "p": 3, "f": 4, "h": 4, "v": 4, "w": 4,
 "y": 4, "k": 5, "j": 8, "x": 8, "q": 10, "z": 10}
words = []

n = int(input())
for i in range(n):
    words.append(input())
letters = input()

best_word = ""
points = 0
for word in words:
    new_sum = 0
    for letter in word:
        if word.count(letter) > letters.count(letter):
            new_sum = 0
            break
        new_sum += alphabet[letter]
    if new_sum > points:
        points = new_sum
        best_word = word

print(best_word)
