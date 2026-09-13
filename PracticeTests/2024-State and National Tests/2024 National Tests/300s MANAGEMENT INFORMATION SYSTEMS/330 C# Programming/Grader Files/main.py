   #GIVEN
class InventoryProductsTypes:

   def __init__(self, *inp):
      if len(inp) == 0:
         self.symbol = "###"
         self.name = "Generic"
         self.price = 0
         self.inventory = 0
      else:
         self.symbol = inp[0]
         self.name = inp[1]
         self.price = inp[2]

   def getSymbol(self):
      return self.symbol

   def getName(self):
      return self.name

   def getPrice(self):
      return self.price

   def getValue(self):
      return self.price * self.inventory

   def getInventory(self):
      return self.inventory

   def createInventory(self, s):
      self.inventory += s

   def sellInventory(self, s):
      self.inventory -= s


###########################################

#STUDENT POINT  //SC12
class Pastas(InventoryProductsTypes):

   type = "Pasta"

   def __init__(self, *inp): #SC13
      if len(inp) == 0:
         super().__init__(self)
      else:
         self.symbol = inp[0]#SC13
         self.name = inp[1]#SC13
         self.price = inp[2]#SC13
         self.inventory = inp[3]#SC13

   def getValue(self):
      return self.price * self.inventory
#STUDENT POINT  #SC1
   def __str__(self):
      return "{Symbol: " + self.getSymbol(
         ) + "}  " + " {Type: Pasta}  " + " {Pasta Name: " + self.getName(
         ) + "}  " + " {Price: $" + "{:,.2f}".format(
         self.getPrice()) + "}  " + " {Total Inventory: " + str(
           self.inventory) + "}  " + " {Total Value: $" + "{:,.2f}".format(self.getValue()) +"}"  

   def getInventory(self):
      return self.inventory

   def getSymbol(self):
      return self.symbol

   def getName(self):
      return self.name

   def getPrice(self):
      return self.price

   def createInventory(self, s):
      self.inventory += s

   def sellInventory(self, s):
      self.inventory -= s


###########################################

#STUDENT POINT 
class Pizzas(InventoryProductsTypes):  #SC14

   transactionFee = 7.55
   type = "Pizza"

   def __init__(self, *inp):  #SC15
      if len(inp) == 0:
         super().__init__(self)
      else:
         self.symbol = inp[0]#SC15
         self.name = inp[1]#SC15
         self.price = inp[2]#SC15
         self.inventory = inp[3]#SC15

   def getValue(self):
      return self.price * self.inventory
#STUDENT POINT  #SC2
   def __str__(self):
      return "{Symbol: " + self.getSymbol(
         ) + "}  " + " {Type: Pizza}  " + " {Pizza Name: " + self.getName(
         ) + "}  " + " {Price: $" + "{:,.2f}".format(
         self.getPrice()) + "}  " + " {Total Inventory: " + str(
           self.inventory) + "}  " + " {Total Value: $" + "{:,.2f}".format(self.getValue()) +"}"

   def sellInventory(self, s):
      self.inventory -= s

   def getInventory(self):
      return self.inventory

   def getSymbol(self):
      return self.symbol

   def getName(self):
      return self.name

   def getPrice(self):
      return self.price

   def createInventory(self, s):
      self.inventory += s

   def getTransactionFee(self):
      return self.transactionFee


###########################################

#STUDENT POINT
class Warehouse:

   def __init__(self):
      self.lista = []
      self.size = 0
      self.pastaCount = 0
      self.pizzaCount = 0
 #STUDENT POINT
   def createPizza(self, sym, nam, pri, sha):
      self.t = Pizzas(sym, nam, pri, sha)
      self.lista.append(self.t)
      self.pizzaCount += 1
 #STUDENT POINT
   def createPasta(self, sym, nam, pri, sha):
      self.t = Pastas(sym, nam, pri, sha)
      self.lista.append(self.t)
      self.pastaCount += 1
 #STUDENT POINT
   def getCommand(self):
      self.commandAnswer = ""
      self.commands = ["CREATE", "DISTRO", "LIST", "END"]
      self.test = False
   
      while True:
         test = False
         print("What do you want to do today: CREATE, DISTRO, LIST, or END?")
         commandAnswer = input()
         commandAnswer = commandAnswer.upper()
         for i in self.commands:
            if commandAnswer == i:
               test = True
               break
         if test == True:
            break
   #SC6
      if commandAnswer == "CREATE":
         self.letsCreate()
      
      elif commandAnswer == "DISTRO":
         self.letsDistro()
      
      elif commandAnswer == "LIST":
         self.getWarehouseList()
      
      else:
         print("Good bye")
 #STUDENT POINT
   def getWarehouseTotalValue(self):
      self.tempValue = 0
      for s in self.lista:
         self.tempValue += s.getValue()  #SC7
      return self.tempValue
 #GIVEN
   def __str__(self):
      self.inventoryPrinter = ""
      for a in self.lista:
         self.inventoryPrinter = self.inventoryPrinter + a.__str__() + "\n"
      return self.inventoryPrinter
 #STUDENT POINT
   def getWarehouseList(self):
      print("There are " + str(self.pizzaCount) + " Pizzas and " +
             str(self.pastaCount) + " Pasta's.")
      print(self.__str__())  #SC8
      print("This is the Grand Total of the warehouse: $" +
             "{:,.2f}".format(self.getWarehouseTotalValue()))
      self.getCommand()  #SC8
 #STUDENT POINT
   def letsCreate(self):
   
      self.answerSymbol = ""
      self.answerCount = 0
      self.verify = False
   
      while True:
         print("Which product do you want to produce?")
         self.answerSymbol = input()
         self.answerSymbol = self.answerSymbol.upper()
         self.verify = self.symbolEntryVerification(self.answerSymbol)
         if self.verify == False:
            print("Incorrect symbol entry")
         else:
            break
      #STUDENT POINT
      try:  #SC4
         while True:
            print(
               "How many of this product do you want to create? (NOTE: 1000 pizzas is the maximum limit the warehouse can store per SKU)"
               )
            self.answerCount = int(input())
            self.verify = self.dataEntryVerification(self.answerCount,
                                                      self.answerSymbol, True)
            if self.verify == False:
               print("Incorrect data entry")
            else:
               break
         self.transaction(self.answerSymbol, self.answerCount, True)
      except:
         print("You have entered in the wrong value type")
         self.letsCreate()
 #STUDENT POINT 
   def letsDistro(self):
   
      self.answerSymbol = ""
      self.answerCount = 0
      self.verify = False
   
      while True:
         print("Which product do you want to sell to our distributors?")
         self.answerSymbol = input()
         self.answerSymbol = self.answerSymbol.upper()
         self.verify = self.symbolEntryVerification(self.answerSymbol)
         if self.verify == False:
            print("Incorrect symbol entry")
         else:
            break
      #STUDENT POINT #SC5
      try: 
         while True:
            print("How many inventory units do you want to sell?")
            self.answerCount = int(input())
            self.verify = self.dataEntryVerification(self.answerCount,
                                                      self.answerSymbol, False)
            if self.verify == False:
               print("Incorrect data entry")
            else:
               break
         self.transaction(self.answerSymbol, self.answerCount, False)
      except:  #SC5
         print("You have entered in the wrong value type.")
         self.letsDistro()
 #STUDENT POINT
   def symbolEntryVerification(self, sym):
      for i in self.lista:  #SC10
         if sym == i.getSymbol():
            return True
      return False
 #STUDENT POINT
   def dataEntryVerification(self, amt, sym, createOrDistro):
   
      self.temp = 0
      #SC11  #Checks range to create 
      if amt < 0:
         return False
      if amt > 1000:
         return False
      if createOrDistro:
         return True
    #SC11 #Checks inventory amounts for distro
      for i in self.lista:
         if sym == i.getSymbol():
            temp = i.getInventory()
            if amt > temp:
               return False
            else:
               return True
   
      return False
 #STUDENT POINT
   def transaction(self, sym, amt, createOrDistro):
      for i in self.lista:  #SC9
         if sym == i.getSymbol():
            if createOrDistro:
               i.createInventory(amt)
            else:
               i.sellInventory(amt)
      self.getWarehouseList()
 #GIVEN
   def getSize(self):
      return self.size
 #GIVEN
   def isEmpty(self):
      return self.size == 0


###############################################
#DRIVER SECTION 
#READ THE FILE AND CREATE THE PRODUCTS
#GIVEN
wareHouse1 = Warehouse()
productType = ""
productSymbol = ""
productName = ""
productPrice = 0.0
productVolume = 0
#STUDENT POINT #SC3
try:
   sc = open("InventoryText.txt", "r")
   arr = sc.readline().split(",")
   i = 0
   endOfFile = False
   while True:
      productType = arr[i]
      if productType.upper() == "STOP":
         break
      else:
         i += 1
         productSymbol = arr[i]
         i += 1
         productName = arr[i]
         i += 1
         productPrice = float(arr[i])
         i += 1
         productVolume = int(arr[i])
         i += 1
      if productType.upper() == "P":
         wareHouse1.createPizza(productSymbol, productName, productPrice, productVolume)
      elif productType.upper() == "A":
         wareHouse1.createPasta(productSymbol, productName, productPrice, productVolume)

except OSError as e:  #SC3
   print("The text file was not found.")
   exit()
wareHouse1.getCommand()
