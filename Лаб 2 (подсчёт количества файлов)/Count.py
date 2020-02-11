import sys
import argparse
import os
import shutil
import glob

def createParser ():
	parser = argparse.ArgumentParser()
	parser.add_argument ('-R', action = 'store_true', help = 'Enable recoursion while counting files')
	parser.add_argument ('-D', nargs = 1, type = str, help = 'Set directory to count files')
	parser.add_argument ('ext', nargs='*', help = 'List of masks')
	return parser

if __name__ == '__main__':
	parser = createParser()
	args = parser.parse_args(sys.argv[1:])
	
	if args.D:
		for dir in args.D:
			if os.path.exists(dir):
				path = dir
			else:
				print("Directory {} doesn't exist.".format(dir))
				exit(-1)
	else:
		path = os.path.dirname(os.path.abspath(__file__))
				
	if args.R:
		j = 0
		for rootdir, dirs, files in os.walk(path):
			for file in files:
				if len(args.ext) == 0:
					j = j + 1
				else:
					k = 0
					for i in args.ext:
						if i in file:
							k = 1
					if k == 1:
						j = j + 1
	else:
		j = 0
		for rootdir, dirs, files in os.walk(path):
			for file in files:
				if rootdir == path:
					if len(args.ext) == 0:
						j = j + 1
					else:
						k = 0
						for i in args.ext:
							if i in file:
								k = 1
						if k == 1:
							j = j + 1

	print("{}".format(j))
	exit(j)
