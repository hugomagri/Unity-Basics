# 🗡️ Ataque Melee (Corpo a Corpo)

## 📖 Descrição
Executa um ataque próximo (espada, soco, etc.) que causa dano a inimigos dentro de uma área.

## 🛠️ Passo a Passo
1. Crie um objeto `Player` com `BoxCollider2D` e `Rigidbody2D`.
2. Adicione um objeto vazio como filho chamado `PontoAtaque`.
3. Adicione o script **AtaqueMelee.cs** ao `Player`.
4. Defina o `PontoAtaque` e a camada dos inimigos (`inimigoLayer`).
5. Use **Barra de Espaço** para atacar.

🧠 Dica

Para adicionar animação, crie um trigger no Animator chamado Atacar e dispare-o dentro do método Atacar().