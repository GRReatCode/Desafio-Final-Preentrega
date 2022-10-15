/*
BulletsPower
—------------------------------------------------------
USO: PLAYER - Lo utiliza  la bala especial del POWER UP BULLET

FUNCIÓN: Hace que las balas se destruyan cuando colisionan con diferentes objetos

EVENTOS: Dispara los siguientes eventos…

//------------------------------------------------
La Bala del PLAYER golpea con OBJETOS del entorno

BulletPower.OnGolpeACaja.Invoke();      

//------------------------------------------------
La Bala del PLAYER golpea con otras Balas Enemigas

BulletPower.OnGolpeABalas.Invoke();
BulletPower.OnGolpeABalas.Invoke();
BulletPower.OnGolpeABalas.Invoke();

//------------------------------------------------
La Bala del PLAYER golpea con ENEMIGOS

BulletPower.OnGolpeAEnemigo.Invoke();
BulletPower.OnGolpeAEstatua.Invoke();
BulletPower.OnGolpeABoos.Invoke();
      
Todos estos eventos sirven para sumar puntos en HIGHSCORE
en HIGHSCORE devuelven métodos que suman puntos…
*/
