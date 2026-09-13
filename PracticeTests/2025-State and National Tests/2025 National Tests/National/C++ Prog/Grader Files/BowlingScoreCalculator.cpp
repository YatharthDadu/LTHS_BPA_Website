// Contestant Number: ____________________
// Bowling Score Calculator
// File: BowlingScoreCalculator.cpp

#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>
#include <string>
#include <cstdlib>
using namespace std;

// Class representing a single bowling game.
class BowlingGame {
private:
    vector<int> balls;  // All ball scores for the game

public:
    BowlingGame(const vector<int>& scores) : balls(scores) {}

    // Calculate final score using standard bowling rules.
    int calculateScore() {
        int score = 0;
        int index = 0;  // Index into the balls vector
        // A standard game has 10 frames.
        for (int frame = 0; frame < 10; frame++) {
            // Strike: first ball is 10.
            if (balls[index] == 10) {
                score += 10 + balls[index + 1] + balls[index + 2];
                index += 1;  // Strike uses one ball in the frame.
            }
            // Spare: two balls sum to 10.
            else if (balls[index] + balls[index + 1] == 10) {
                score += 10 + balls[index + 2];
                index += 2;
            }
            // Open frame.
            else {
                score += balls[index] + balls[index + 1];
                index += 2;
            }
        }
        return score;
    }
};

int main() {
    ifstream infile("Bowling.txt");
    if (!infile) {
        cout << "Error: Could not open Bowling.txt" << endl;
        return 1;
    }

    cout << "Bowling Score Calculator" << endl << endl;

    string line;
    int gameNumber = 1;
    // Process each game (each line in the file).
    while (getline(infile, line)) {
        if (line.empty()) continue; // Skip empty lines

        vector<int> scores;
        stringstream ss(line);
        string token;
        // Split the line by commas.
        while (getline(ss, token, ',')) {
            // Trim leading and trailing whitespace.
            size_t start = token.find_first_not_of(" \t");
            size_t end = token.find_last_not_of(" \t");
            if (start != string::npos && end != string::npos)
                token = token.substr(start, end - start + 1);
            // Convert token to integer.
            int val = stoi(token);
            scores.push_back(val);
        }

        BowlingGame game(scores);
        int finalScore = game.calculateScore();
        cout << "Game " << gameNumber << " Final Score: " << finalScore << endl;
        gameNumber++;
    }

    infile.close();
    return 0;
}
