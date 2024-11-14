Feature: BuyAProduct

This is a summary about an user can do a simple buy in Aliexpress and validate the shopping car

Scenario: An user buy a product
	Given An user selects a country <country>
	When An user search a product and choosed it <product>
	Then An user validates gran total
	Examples: 
| country  | product |
| Colombia | termo   |

