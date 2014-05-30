TODO:
-----
1. Break up the class Field:
	1.1 'Field' should contain only the 2d array, props for rows and cols, ToString implementation    
	1.2 'IGeneratable' interface - property for getting the symbol and method for symbol generation    
	1.3 New class 'Mine' - has a symbol to represent the mine; implements 'IGeneratable' interface    
	1.4 'IGenerator' interface - method for generating 'IGeneratable' objects
	1.5 New class 'MineGenerator' - implements 'IGenerator'   
	1.6 New class 'AdjacencyMap' - counts the appearance of a 'IGenerable' object around every cell in 2d array   
    
2. ...