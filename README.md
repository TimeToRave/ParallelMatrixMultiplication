# Программа произведения двух квадратных матриц в многопоточном приложении

[![Tests](https://github.com/TimeToRave/ParallelMatrixMultiplication/actions/workflows/Tests.yml/badge.svg)](https://github.com/TimeToRave/ParallelMatrixMultiplication/actions/workflows/Tests.yml)

## Дано

Две матрицы A и B размерности NxN

## Цель

Вычислить произведение матриц, с учетом следущего условия:

- Элементы c[i,j] матрицы произведения С = A×B вычисляются параллельно p однотипными потоками. Если некоторый поток уже вычисляет элемент c[i,j] матрицы C, то следующий приступающий к вычислению поток выбирает для расчета элемент c[i,j+1]
