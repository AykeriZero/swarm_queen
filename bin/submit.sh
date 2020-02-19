#!/bin/bash

mkdir -p Submit

cp -r Assets/ Submit/Assets
cp -r ProjectSettings/ Submit/ProjectSettings
cp -r Builds/* Submit/
cp -r GOLD_SPIKE.txt Submit/GOLD_SPIKE.txt
cp -r PORTFOLIO.txt Submit/PORTFOLIO.txt
cp -r ITERATION.txt Submit/ITERATION.txt


zip -r songya_swarm_queen.zip Submit

hh Submit

