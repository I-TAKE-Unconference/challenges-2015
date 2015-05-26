package com.itakeunconf;

import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        List<String> columns = new ArrayList<String>();
        columns.add("FirstName");
        columns.add("LastName");
        columns.add("Email");
        GenerateCsv csvGenerator = new GenerateCsv("test.csv", columns);

        List<String> row = new ArrayList<String>();
        row.add("John");
        row.add("Doe");
        row.add("john.doe@anonymous.com");

        try {
            csvGenerator.writeRow(row);
        } catch (CSVWriteException e){
            e.printStackTrace();
        }

        System.out.println("File 'test.csv' created");
    }
}
