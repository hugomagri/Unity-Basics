# 💥 Ataque com Projétil

## 📖 Descrição
Permite disparar projéteis (como flechas, balas ou magias) em direção à frente do jogador.

## 🛠️ Passo a Passo
1. Crie um objeto `Player` e adicione o script `AtaqueProjetil.cs`.
2. Crie um `Projetil.prefab` com:
   - `Rigidbody2D` (Body Type: Dynamic, Gravity Scale = 0)
   - `Collider2D` com `isTrigger` marcado.
   - Script `Projetil.cs`.
3. No `Player`, arraste o prefab do projetil para o campo `ProjetilPrefab`.

💡 Dica

Adicione uma partícula de impacto no OnTriggerEnter2D antes de destruir o projetil.