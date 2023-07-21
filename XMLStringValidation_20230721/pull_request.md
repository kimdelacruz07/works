#What?
Created a simple console application that determines whether a string is a valid XML string. This code does not include System.XML and Regular Expression in validating the strings. This code includes entrypoint bool DetermineXml(string xml)


#How?
In this console application, the DeterminXml method takes a string xml as input and iterates through each character of the XML string. When it encounters an opening bracket [<], it looks for the corresponding closing bracket [>] to extract the tag. If it finds an opening tag, it add it to the list of opening tags, and if it finds a closing tag, it gets the last item from the list of opening tags and checks if it matches the closing tag.

The method returns true if all tags have corresponding opening and closing tags and if the list of opening tag is empty at the end of the loop (indicating all opening tags have the same closing tags and were properly closed). Otherwise, it returns false.

#Test?
Test cases were given by Boostdraft to test the validity of XML strings.
