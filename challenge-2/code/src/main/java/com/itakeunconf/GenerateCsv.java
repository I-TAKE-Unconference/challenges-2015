package com.itakeunconf;

import java.io.FileWriter;
import java.io.IOException;
import java.util.List;

public class GenerateCsv {

    String csvFileName;
    List<String> columnNames;

    public GenerateCsv(String csvFileName, List<String> columnNames) {
        this.csvFileName = csvFileName;
        this.columnNames = columnNames;
    }

    public void writeRow(List<String> rowValues) throws CSVWriteException {
        try {
            FileWriter writer = new FileWriter(csvFileName);

            writeHeader(writer);
            writeRow(rowValues, writer);

            writer.flush();
            writer.close();
        } catch (IOException e) {
            throw new CSVWriteException("Could not create CSV file", e);
        }
    }

    private void writeRow(List<String> rowValues, FileWriter writer) throws IOException {
        for (String value : rowValues) {
            writer.append(value);
            writer.append(',');
        }

        writer.append('\n');
    }

    private void writeHeader(FileWriter writer) throws IOException {
        for (String columnName : columnNames) {
            writer.append(columnName);
            writer.append(',');
        }
        writer.append('\n');
    }
}