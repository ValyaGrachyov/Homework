using Metalfactory;

var cw = new Worker();

var d = new Director(cw);

d.Melt();
d.CreateFullIngot();
d.CreateMeltIngot();

