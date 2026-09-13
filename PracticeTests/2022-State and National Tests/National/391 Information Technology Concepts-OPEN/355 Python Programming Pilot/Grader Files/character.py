# Character Information Classes
# MemberID

class Character:
    def __init__(self, name, id_number):
        self.__name = name
        self.__id_number = id_number

    def set_name(self, name):
        self.__name = name

    def set_id_number(self, id_number):
        self.__id_number = id_number

    def get_name(self):
        return self.__name

    def get_id_number(self):
        return self.__id_number

class Hero(Character):
    def __init__(self, name, id_number, level, loot):
        # Call superclass __init__ method.
        Character.__init__(self, name, id_number)

        # Initialize the level and loot attributes.
        self.__level = level
        self.__loot = loot

    # Mutator functions for level and loot.
    def set_level(self, level):
        self.__level = level

    def set_pay_rate(self, __loot):
        self.__loot = loot

    # Accessor functions for level and loot.
    def get_level(self):
        return self.__level

    def get_loot(self):
        return self.__loot

class Boss(Character):
    def __init__(self, name, id_number, level, hp, attack_damage):
        # Call superclass __init__ method.
        Character .__init__(self, name, id_number)

        # Initialize the level, hp, attack damanage, lifespan attributes.
        self.__level = level
        self.__hp = hp
        self.__attack_damage = attack_damage
        self.__lifespan = 0

    # Mutator functions for level, hp, attack damanage, lifespan.
    def set_level(self, level):
        self.__level = level

    def set_hp(self, hp):
        self.__hp = hp

    def set_attack_damage(self, attack_damage):
        self.__attack_damage = attack_damage

    def set_lifespan(self, lifespan):
        self.__lifespan = lifespan

    # Accessor functions for level, hp, attack damanage, lifespan
    def get_level(self):
        return self.__level

    def get_hp(self):
        return self.__hp

    def get_attack_damage(self):
        return self.__attack_damage

    def get_lifespan(self):
        return (self.__hp / 300)
