class Pizzas:
  unitPrice = 0.0
  inventoryCount = 0 
  pizzaSymbol = ""
  pizzaName = ""
  
   
  def __init__(self, pizzaSymbol, pizzaName, unitPrice, inventoryCount):  #SC12
    self.pizzaSymbol = pizzaSymbol
    self.pizzaName = pizzaName
    self.unitPrice = unitPrice
    self.inventoryCount = inventoryCount

   
  def getValue(self):  #SC14
    return (float(self.unitPrice) * int(self.inventoryCount))
  
   
  def __str__(self):   #SC13
    return f"Pizza Type Symbol:{self.pizzaSymbol}\tPizza Name: {self.pizzaName}\tUnit Price: {self.unitPrice}\tActive Inventory: {self.inventoryCount}\tEstimated Inventory ($): {self.getValue()}"
  
   
  def printPizzaType(self):  #SC15
    return self.__str__()
  
