class Octane:
    def __init__(self, name: str):
        self.price = 0
        self.name = name

    def discount(self, discnt:float) -> None:
        self.price = format(self.price - (self.price * discnt),".2f")

    def no_discount(self) -> None:
        self.price = self.price


def get_octanes() -> list:
    level = []
    premium = Octane("Premium 93")
    premium.price = 4.68
    level.append(premium)
    midgrade= Octane("Midgrade 89")
    midgrade.price = 4.55
    level.append(midgrade)
    regular = Octane("Regular 87")
    regular.price = 4.42
    level.append(regular)
    return level



def get_octane(level: list) -> Octane:
    picked = -2  # start loop
    while picked < 0:
        ndx = 0
        if picked == -1:  # had input error
            print(">>>Invalid choice - Please try again.<<<")
        print("\n------ List of levels of octane and price before discount.------")
        for acc in level:
            ndx += 1
            print("{:>4}-{:<15} ${:>8.2f}" .format(ndx, acc.name, acc.price))
        try:
            picked = int(input("Which level of octane do you wish to use? "))
            if picked < 1 or picked > len(level):
                picked = -1  # input error
        except:
            picked = -1  # input error

        picked -= 1  # set account number to index
    return level[picked]