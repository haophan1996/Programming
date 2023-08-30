#!/bin/env zsh

mypath=$(dirname  ${(%):-%N})

java -cp "$mypath/antlr-4.13.0-complete.jar" 'org.antlr.v4.gui.Interpreter' $@
