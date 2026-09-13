#include <iostream>
#include <vector>
#include <fstream>
#include <sstream>

using namespace std;

struct coords
{
	int x;
	int y;
};

class level
{
public:
	vector<vector<char>> _map;

	level() 
	{

	}

	void render(coords start)
	{
		for (int i = 0; i < _map.size(); i++) 
		{
			for (int j = 0; j < _map[i].size(); j++)
			{
				if (i == start.x && j == start.y)
				{
					cout << '@';
				}
				else
				{
					cout << _map[i][j];
				}
			}
			cout << endl;
		}
	}

	static bool traverse(int i, int j, level lev, vector<coords>& path)
	{
		bool found = false;

		if (lev._map[i][j] == 'o')
		{
			cout << "End found at " << j << ", " << i << endl;
			found = true;
		}
		else if (lev._map[i][j] == '.')
		{
			lev._map[i][j] = 'x';

			if (i < lev._map.size() - 1)
			{
				found |= (traverse(i + 1, j, lev, path));
			}
			if (j < lev._map[i].size() - 1 && !found)
			{
				found |= (traverse(i, j + 1, lev, path));
			}
			if (i > 0 && !found)
			{
				found |= (traverse(i - 1, j, lev, path));
			}
			if (j > 0 && !found)
			{
				found |= (traverse(i, j - 1, lev, path));
			}
		}

		if (found)
		{
			coords c = { c.x = i, c.y = j };
			path.push_back(c);
		}

		return found;
	}

	bool load(string path, coords& start)
	{
		string line = "";
		ifstream file(path);
		
		if (file.is_open())
		{
			int j = 0;
			while (file >> line)
			{
				_map.push_back(vector<char>());
				for (int i = 0; i < line.length(); i++)
				{
					if (line[i] == '@')
					{
						start.x = j;
						start.y = i;
						line[i] = '.';
					}

					_map[j].push_back(line[i]);
				}
				j++;
			}
			return true;
		}
		else
			return false;
	}
};

int main()
{
	coords start;
	vector<coords> path = vector<coords>();
	level lev;

	lev.load("map.txt", start);

	lev.render(start);

	cout << endl;

	level::traverse(start.x, start.y, lev, path);

	cout << endl;
	
	for (int i = path.size()-1; i >= 0; i--)
	{
		cout << "Step " << path.size()-i << ": " << path[i].y << ", " << path[i].x << endl;
	}
}