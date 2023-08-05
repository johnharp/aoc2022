let fs = require('fs');

const inputString = fs.readFileSync('./input.txt', 'utf-8').toString();

const input = inputString
    .split('\n\n')
    .map((g) => g.split('\n').map((i) => Number(i)));

const sums = input.map((g) =>
    g.reduce((accumulator, current) => accumulator + current)
);

const sortedSums = sums.sort((a, b) => b-a);

console.log('Part 1', sortedSums[0]);
console.log('Part 2', sortedSums[0] + sortedSums[1] + sortedSums[2]);
