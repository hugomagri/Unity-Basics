# 🎯 Tiro Top-Down

## 📖 Descrição
Permite que o jogador atire projéteis na direção do mouse (top-down) em jogos 2D.  
Inclui o movimento do projétil e destruição ao colidir ou sair da tela.

## 🛠️ Passo a Passo
1. Crie um objeto `Player` com `Rigidbody2D` e `Collider2D`.
2. Adicione o script `PlayerTiro.cs` ao jogador.
3. Crie um prefab de projétil com `Rigidbody2D`, `Collider2D` e o script `Projetil.cs`.
4. Arraste o prefab do projétil para o campo `prefabProjetil` no Inspector do jogador.
5. Ajuste velocidade, taxa de tiro e layer de colisão conforme desejado.
