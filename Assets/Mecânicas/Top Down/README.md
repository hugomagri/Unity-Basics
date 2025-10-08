# 🎮 Movimento Top-Down

## 📖 Descrição
Permite que o jogador se mova em 2 eixos (horizontal e vertical) com controle livre, ideal para jogos estilo **RPG, roguelike ou adventure**.

## 🛠️ Passo a Passo
1. Crie um objeto `Player` na cena.
2. Adicione um `Rigidbody2D` (defina Body Type como Dynamic e desligue "Gravity Scale").
3. Adicione um `BoxCollider2D`.
4. Crie o script `TopDownMovement.cs` e copie o código abaixo.
5. Ajuste a velocidade no Inspector.

🔎 Observações

Configure Rigidbody2D → Collision Detection = Continuous para evitar bugs em colisão.

Se quiser rotacionar o player na direção do movimento, adicione:

## Código C#

if (moveInput.sqrMagnitude > 0.01f)
{
    float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
}
