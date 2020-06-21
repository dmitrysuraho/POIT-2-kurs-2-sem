package com.company;

import javax.xml.stream.XMLInputFactory;
import javax.xml.stream.XMLStreamConstants;
import javax.xml.stream.XMLStreamException;
import javax.xml.stream.XMLStreamReader;
import java.io.FileInputStream;
import java.io.FileNotFoundException;

public class Parser {
    public static void Parse(String file) throws FileNotFoundException, XMLStreamException {
        XMLInputFactory factory = XMLInputFactory.newInstance();
        XMLStreamReader parser = factory.createXMLStreamReader(new FileInputStream(file));
        while(parser.hasNext()){
            int event = parser.next();
            if(event == XMLStreamConstants.START_ELEMENT){
                System.out.println(parser.getLocalName());
            }
        }
    }
}
