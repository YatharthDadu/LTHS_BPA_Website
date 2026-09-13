import info

# This is one possible answers
def get_discount(start_price, card) -> float:
    if card >= 4000:
        price = start_price - start_price * 0.02
    elif card >= 7000 and card < 4000:
        price = start_price - start_price * 0.03
    else:
        price = start_price - start_price * 0.04
    return price


def print_error(text: str) -> None:
    print("#" * (len(text) + 8))
    print("### " + text + " ###")
    print("#" * (len(text) + 8))
    print()

def total_price(ending_price):
    gallon = int(input("How many gallons of gas are you purchasing? "))
    t_price = ending_price * gallon
    return t_price

gas_price = info.get_octanes()
keep_running = True
while keep_running:
    answer = input("Would you like to use your discount?\n\t(y)es\n\t(n)o\n\te(x)it the application.\n\t")
    answer = answer.lower()
    if answer == "y":
        cards = 0
        while cards == 0:
            card_num = int(input("What is your card number? "))
            if card_num > 1000 or card_num < 9999:
                cards = 1
            else:
                print("Invalid card number.")
        grade_to_use = info.get_octane(gas_price)
        starting_price = grade_to_use.price
        ending_price = get_discount(starting_price, card_num)
        print()
        print("-> {} discount price: ${:.2f}".format(grade_to_use.name, ending_price))
        print()y
        keep_running = False

    elif answer == "n":
        grade_to_use = info.get_octane(gas_price)
        starting_price = grade_to_use.price
        ending_price = starting_price
        print()
        keep_running = False
    elif answer == "x":
        keep_running = False
    else:
        print_error("I did not understand.")

total = total_price(ending_price)
print("Your total cost of gas is: ${:.2f}".format(total))
print("Thank you; come again.")


