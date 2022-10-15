/*
Bullets
—------------------------------------------------------
USO: PLAYER - Lo utiliza  la bala común PlayerBullet

FUNCIÓN: Hace que las balas se destruyan cuando colisionan con diferentes objetos

EVENTOS: Dispara los siguientes eventos…

//------------------------------------------------
La Bala del PLAYER golpea con OBJETOS del entorno

Bullet.OnGolpeACaja.Invoke();      

//------------------------------------------------
La Bala del PLAYER golpea con otras Balas Enemigas

Bullet.OnGolpeABalas.Invoke();
Bullet.OnGolpeABalas.Invoke();
Bullet.OnGolpeABalas.Invoke();

//------------------------------------------------
La Bala del PLAYER golpea con ENEMIGOS

Bullet.OnGolpeAEnemigo.Invoke();
Bullet.OnGolpeAEstatua.Invoke();
Bullet.OnGolpeABoos.Invoke();
      
Todos estos eventos sirven para sumar puntos en HIGHSCORE
en HIGHSCORE devuelven métodos que suman puntos…
*/
