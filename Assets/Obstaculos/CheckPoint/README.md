# 🪧 Checkpoints

## 📖 Descrição
Permite que o jogador retorne ao último ponto ativado após morrer ou reiniciar a fase.  
Útil para salvar progresso em jogos de plataforma ou aventura.

---

## 🛠️ Passo a Passo
1. Crie um objeto `Checkpoint` com `Collider2D` (IsTrigger marcado).
2. Adicione o script `Checkpoint.cs`.
3. Defina a **Tag** do jogador como `Player`.
4. No script do jogador, adicione uma referência para o último checkpoint atingido.
5. Quando o jogador morrer, reposicione-o na posição salva.

