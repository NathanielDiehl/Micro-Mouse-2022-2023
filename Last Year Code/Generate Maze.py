from operator import truediv
import robot_sim
import random
import pygame

#Creates a blank maze array (all walls)
def makeMaze(m, row, col):
    for i in range(row):
        m.append([])
        for j in range(col):
            m[i].append([1,1,1,1,0])

# Draws the maze
def drawMaze(m, s, row, col):
    for i in range(row):
        for j in range(col):
            if m[i][j][0] == 1:
                course.line(x1=i*s,y1=j*s,x2=(i)*s,y2=(j+1)*s,c=blue)
            if m[i][j][1] == 1:
                course.line(x1=i*s,y1=j*s,x2=(i+1)*s,y2=(j)*s,c=blue)
            if m[i][j][2] == 1:
                course.line(x1=(i+1)*s,y1=j*s,x2=(i+1)*s,y2=(j+1)*s,c=blue)
            if m[i][j][3] == 1:
                course.line(x1=i*s,y1=(j+1)*s,x2=(i+1)*s,y2=(j+1)*s,c=blue)

#Marks the cell at (x, y) with a red line
def markSpace(s, x, y):
    course.line(x1=x*s,y1=(y)*s,x2=(x+1)*s,y2=(y+1)*s,c=red)

#Deletes wall position p in cell (x, y)
def deleteWall(m, x, y, p):
    m[x][y][p] = 0

    if p == 0 and x > 0:
        m[x-1][y][2] = 0
    if p == 1 and y > 0:
        m[x][y-1][3] = 0
    if p == 2 and y < len(m):
        m[x+1][y][0] = 0
    if p == 3 and y < len(m[0]):
        m[x][y+1][1] = 0

#fills pd with a list of neighboring  naboring cells
def getUnvisitedCells(m, x, y, pd):
    pd.clear()
    if x < len(m) - 1 and m[x+1][y][4] == 0:
        pd.append(2)
    if y < len(m[0]) - 1 and m[x][y+1][4] == 0:
        pd.append(3)
    if x > 0 and m[x-1][y][4] == 0:
        pd.append(0)
    if y > 0 and m[x][y-1][4] == 0:
        pd.append(1)

#Creates a maze by rooming walls
def mazeMaker(m, x, y):
    m[x][y][4] = 1 #mark cell as visited

    possibleDirections =[]
    getUnvisitedCells(m, x, y, possibleDirections)  #get possible directions

    while len(possibleDirections) > 0:
        direction = possibleDirections[random.randrange(0, len(possibleDirections))] #pick a direction
        deleteWall(m, x, y, direction) #remove wall
        if direction == 0:  #move to next cell
            mazeMaker(m, x-1, y)
        elif direction == 1:
            mazeMaker(m, x, y-1)
        elif direction == 2:
            mazeMaker(m, x+1, y)
        elif direction == 3:
            mazeMaker(m, x, y+1)
        getUnvisitedCells(m, x, y, possibleDirections)  #reset possible directions


FPS = 60
flip = False
white = (255,255,255,255)
blue = (0,0,255,255)
green = (0,255,0,255)
red = (255,0,0,255)
mod = 0

def algorithm(robot, time, events):
    global white
    global blue
    global flip
    global green
    global red
    global mod

    sensorData = robot.getSensorData()
     
    for event in events:
        if event.type == pygame.QUIT:
            pygame.quit()
            return


course = robot_sim.Course(pixelsX=800,
                          pixelsY=800,
                          courseResolutionX=180,
                          courseResolutionY=180)
        


# -- Draw course --
maze = []

makeMaze(maze, 8, 8)
mazeMaker(maze, 0, 7)
drawMaze(maze, 20, 8, 8)





# Sensors:
#                 | 0°
#                 |
#            __________
#     -90°  |          |
#    -------S <- (x,y) |
#    |--d---|          |
#           |          |
#           |  Robot   |
#           |          |
#           |          |
#      (0,0)x----------
#
sensors = {
    "TL": robot_sim.Sensor(x=0,y=50,d=300,angle=-90,debug=True),
    "BL": robot_sim.Sensor(x=0,y=0,d=300,angle=-90,debug=True),
    "BR": robot_sim.Sensor(x=25,y=0,d=300,angle=90,debug=True),
    "TR": robot_sim.Sensor(x=25,y=50,d=300,angle=90,debug=True),
    "Front": robot_sim.Sensor(x=12.5,y=50,d=300,angle=0,debug=True)
}
cameras = {}
robot = robot_sim.RobotSim(location=(50,650),
                           length=50,
                           width=25,
                           algorithm=algorithm,
                           sensors=sensors,
                           cameras=cameras)
robot_sim.run(course, robot, FPS)
