
class InventoryProductsTypes:

   #Constructor needs to handle four arguments: String (Symbol), String (Name), Integer (Price), Integer (Inventory)

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


class Pastas():

   type = "Pasta"



   def getValue(self):


   def __str__(self):


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


class Pizzas():

   transactionFee = 7.55



   def getValue(self):


   def __str__(self):


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


class Warehouse:

   def __init__(self):

   def createPizza():


   def createPasta():


   def getCommand(self):
      #Commands #"CREATE", "DISTRO", "LIST", "END"

      #STEP 1 Statement: "What do you want to do today: CREATE, DISTRO, LIST, or END?"
      #STEP 1 End: "Good bye"

   def getWarehouseTotalValue(self):

   def __str__(self):

   def getWarehouseList(self):
      #List Output: "There are " [# of pizzas] " Pizzas and " [# of pastas] " Pasta's.")
      #List Output:"This is the Grand Total of the warehouse: $"

 #STUDENT POINT
   def letsCreate(self):

      #STEP 2 Create:"Which product do you want to produce?"
      #STEP 2 Create/Distro Error:"Incorrect symbol entry"
      #STEP 3 Inventory Units to Create:"How many of this product do you want to create? (NOTE: 1000 pizzas is the maximum limit the warehouse can store per SKU)"
      #STEP 3 Error:"Incorrect data entry"
      #STEP 3 Error:"You have entered in the wrong value type"

   def letsDistro(self):

      #STEP 2 Distro: "Which product do you want to sell to our distributors?"
      #STEP 2 Create/Distro Error:"Incorrect symbol entry"
      #STEP 3 Inventory Units to Create:"How many inventory units do you want to sell?"
      #STEP 3 Error:"Incorrect data entry"
      #STEP 3 Error:"You have entered in the wrong value type"

   def symbolEntryVerification(self, sym):

   def dataEntryVerification(self, symbol, amount, createOrDistro):

   def transaction(self, symbol, amount, createOrDistro):

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


wareHouse1.getCommand()
