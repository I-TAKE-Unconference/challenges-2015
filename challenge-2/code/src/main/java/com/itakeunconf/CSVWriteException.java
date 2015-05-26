package com.itakeunconf;

public class CSVWriteException extends Exception {
    public CSVWriteException(String message, Exception e) {
        super(message, e);
    }
}
