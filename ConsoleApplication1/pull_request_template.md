#What?
Created a simple console application that determines whether a string is a valid XML string.
This code does not include System.XML and Regular Expression in validating the strings.
This code includes entrypoint bool DetermineXml(string xml)

#How?
1. I checked each one characters of the string by using a loop.
2. I'll gather all the characters in a list of opening tags (those that are in between [<] and [>] sign).
3. If I got a closing tag (those that are in between [</] and [>], I'd compare it to the last string from the opening tag list.
   -If it is the same, I'd remove that string from the opening tag list.
   -If it is not the same, the loop will be terminated and return false.
4. After the loop is finished, I'd check the opening tag list.
   -If the list is empty, it means that all tag have appropriate and ordered pairs and the 
   -If the the list is not empty, it will return false.

#Test?
