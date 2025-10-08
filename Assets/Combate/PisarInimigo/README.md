# 🦘 Dano ao Pular sobre o Inimigo

## 📖 Descrição
Permite que o jogador derrote inimigos ao pular sobre eles.  
Ao cair em cima, o jogador causa dano no inimigo e quica para cima.  
Se encostar pelos lados, o jogador pode receber dano.

---

## 🛠️ Passo a Passo
1. Crie um `Player` com `Rigidbody2D`, `Collider2D` e o script `PlayerStomp.cs`.
2. Crie um `Inimigo` com `Collider2D` (e opcionalmente `Rigidbody2D` configurado como *Kinematic*) e o script `Vida.cs`.
3. Defina a **Tag** do inimigo como `Inimigo`.
4. Ajuste os valores de `forcaRebote` e `dano` no Inspector conforme necessário.
