#!/bin/env bash

mypath=$(dirname ${BASH_SOURCE[0]})

java -cp "$mypath/antlr-4.13.0-complete.jar" 'org.antlr.v4.gui.Interpreter' $@
