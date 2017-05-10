Feature: SampleFeature2   
     
@HA-10  
Scenario Outline: Add two numbers      
Given "<name>" failed in exam 
Examples:  
| name     |
| Person 1 | 
| Person 2|
| Person 3 |    


@HA-20
Scenario: Add two numbers  without examples   
Given "Person 1" failed in exam    

@HA-30  
Scenario Outline: Add two numbers2    
Given "<name>" failed in exam      
Examples:  
| name     | Designation |  
| Person 1 | Developer2   |
| Person 2 |Developer2   |
| Person 3 |Director2  |  