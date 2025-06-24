# LeetCode

**Número da Lista**: 4<br>
**Conteúdo da Disciplina**: Dividir e Conquistar <br>

## Alunos

|Matrícula | Aluno |
| -- | -- |
| 22/2006178 | Thales Henrique Euflauzino dos Santos  |
| 22/2021924 | Víctor Hugo Lima Schmidt               |

## Sobre

Para explorar o conteúdo do tópico de Dividir e Conquistar, a dupla escolheu quatro exercícios de nível DIFÍCIL na plataforma online [LeetCode](https://leetcode.com/).

## Screenshots

[315. Count of Smaller Numbers After Self - Nível Difícil](https://leetcode.com/problems/count-of-smaller-numbers-after-self/description/?envType=problem-list-v2&envId=divide-and-conquer)

Para resolver o exercício, eu usei uma abordagem de merge sort modificada que conta os números menores durante o processo de ordenação. Criei pares (valor, índice_original) para rastrear a posição original de cada elemento e inicializei um array de resultados. Durante o merge de duas metades ordenadas, quando pegava um elemento da metade esquerda, todos os elementos da metade direita já processados eram menores que ele, então incrementava o contador. Para cada elemento da metade esquerda, adicionava esse contador ao resultado na posição original, retornando o array com a contagem de elementos menores à direita de cada posição.

![315](/assets/315.png)

[327. Count of Range Sum - Nível Difícil](https://leetcode.com/problems/count-of-range-sum/description/?envType=problem-list-v2&envId=divide-and-conquer)

Para resolver o exercício, eu calculei os prefix sums do array para permitir consultas de soma de intervalo em O(1). Em seguida, usei uma abordagem com array ordenado, processando os prefix sums da direita para a esquerda. Para cada prefix sum, utilizei busca binária para encontrar quantos elementos já processados estão dentro do intervalo [prefix_sum[i] + lower, prefix_sum[i] + upper]. Mantive um array ordenado dinamicamente, inserindo cada prefix sum na posição correta usando busca binária, e retornei o total de intervalos válidos encontrados.

![327](/assets/327.png)

[2426. Number of Pairs Satisfying Inequality](https://leetcode.com/problems/number-of-pairs-satisfying-inequality/)

Para resolver este problema, primeiro construí o array `A[i] = nums1[i] − nums2[i]` e então usei a técnica de **contagem de inversões** com merge-sort modificado para contar, em $O(n \log n)$, todos os pares $i<j$ que satisfazem $A[i] \le A[j] + \text{diff}$. Durante o merge das metades já ordenadas, para cada valor da parte esquerda eu avancei um ponteiro na parte direita até que a desigualdade não fosse mais válida e somei o restante de elementos como inversões “válidas”. Em seguida, realizei o merge padrão para manter o array ordenado e garantir o desempenho nas recursões superiores.


![2426](/assets/2426.png)

## Instalação

**Linguagem**: C#, Ruby, Go<br>