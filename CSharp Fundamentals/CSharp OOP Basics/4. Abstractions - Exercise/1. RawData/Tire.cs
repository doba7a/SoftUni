﻿public class Tire
{
    private double pressure;
    private int age;

    public Tire(double pressure, int age)
    {
        this.Pressure = pressure;
        this.age = age;
    }

    public double Pressure { get => pressure; set => pressure = value; }
}