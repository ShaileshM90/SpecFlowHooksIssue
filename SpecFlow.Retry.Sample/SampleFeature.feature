 
Feature: SampleFeature  
@HA-100 
Scenario Outline: Add two numbers Sample      
Given "<name>" failed in exam 
Examples:  
| name     |
| Person 1 | 
| Person 2|
| Person 3 |    


@HA-200
Scenario: Add two numbers  without examples Sample
Given "Person 1" failed in exam    

@HA-300 
Scenario Outline: Add two numbers2 Sample
Given "<name>" failed in exam      
Examples:  
| name     | Designation |  
| Person 1 | Developer2   |
| Person 2 |Developer2   |
| Person 3 |Director2  |  

