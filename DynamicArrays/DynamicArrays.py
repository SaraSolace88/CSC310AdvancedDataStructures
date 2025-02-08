from Contact import ContactClass
import timeit

sTime = timeit.timeit()

dynamicArray = []

file = open("ExtraCreditDataSet.csv", "r")

for line in file:
    data = line.strip().split(",")
    tmp = ContactClass(data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7])
    dynamicArray.append(tmp)

dynamicArray.sort(key = lambda ContactClass: ContactClass.lastName)

for i, contact in enumerate(dynamicArray):
    if (i + 1) % 1000 == 0:
        print(contact)
file.close()

eTime = timeit.timeit()

print(f"Elapsed Time: {eTime - sTime}")