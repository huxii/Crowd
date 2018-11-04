//Maya ASCII 2018 scene
//Name: Level0.ma
//Last modified: Sun, Nov 04, 2018 10:39:08 AM
//Codeset: 1252
requires maya "2018";
requires "stereoCamera" "10.0";
requires "stereoCamera" "10.0";
currentUnit -l meter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201706261615-f9658c4cfc";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -s -n "persp";
	rename -uid "69C2E574-45FA-86C5-802E-A39F733991CA";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -0.19618200001221667 6.5450512516069992 11.922286875948535 ;
	setAttr ".r" -type "double3" -14.138351655335587 -5763.3999999995403 359.99999999927559 ;
	setAttr ".rpt" -type "double3" -2.2632922261941428e-16 1.6490924591784268e-16 4.2076300507971209e-16 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "9F9F5D75-4A7D-841F-FA80-70A4D602A756";
	setAttr -k off ".v" no;
	setAttr ".pze" yes;
	setAttr ".fl" 34.999999999999979;
	setAttr ".ncp" 0.001;
	setAttr ".fcp" 100;
	setAttr ".fd" 0.05;
	setAttr ".coi" 14.459444814327636;
	setAttr ".ow" 0.1;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" 6.897484302520752 99.039260864257813 9.011998176574707 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
	setAttr ".ai_translator" -type "string" "perspective";
createNode transform -s -n "top";
	rename -uid "66779ACE-4511-03FC-0A7C-02826983FC81";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1.9420159535186761 10.003008697063397 -2.3699136377149759 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "8C72CD0B-4D23-1ED8-539F-5999417A8127";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".ncp" 0.001;
	setAttr ".fcp" 100;
	setAttr ".fd" 0.05;
	setAttr ".coi" 9.9161319375342831;
	setAttr ".ow" 1.2266915907901446;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".tp" -type "double3" -0.56626009941101074 8.687675952911377 6.1562392711639404 ;
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "front";
	rename -uid "8D63003B-4463-021D-4F27-9EAF6EDDC189";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1.737984152015263 0.73296660263482394 10.535159443954559 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "DFF33B5B-466E-C4DA-A668-2E893D5CECC7";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".pze" yes;
	setAttr ".ncp" 0.001;
	setAttr ".fcp" 100;
	setAttr ".fd" 0.05;
	setAttr ".coi" 12.901533894400883;
	setAttr ".ow" 6.4935960706415861;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".tp" -type "double3" 341.66681618997438 272.10206587084576 -236.63744504463244 ;
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "side";
	rename -uid "2744D650-4E7C-1DC6-BA99-4BB4646D91F7";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 12.753686086941897 0.070203558480603903 -2.150747855991582 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "20AB63EE-4379-F9DD-4B1B-BFA8F79D4CDB";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".pze" yes;
	setAttr ".ncp" 0.001;
	setAttr ".fcp" 100;
	setAttr ".fd" 0.05;
	setAttr ".coi" 15.53745086388796;
	setAttr ".ow" 1.4188037085439651;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".tp" -type "double3" -278.37647769460614 876.77610364682869 -415.35890141802065 ;
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -n "Reference";
	rename -uid "C3C50B0E-4C52-6C3A-8400-4CAF56BDC878";
createNode transform -n "UVPlane" -p "Reference";
	rename -uid "E3BDA3CB-4BEE-C2F8-2C81-03961542A729";
	setAttr ".rp" -type "double3" 2.5 0 2.5 ;
	setAttr ".sp" -type "double3" 2.5 0 2.5 ;
createNode mesh -n "UVPlaneShape" -p "UVPlane";
	rename -uid "7F238F28-494C-68E5-B867-64B412E48AC9";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 121 ".uvst[0].uvsp[0:120]" -type "float2" 0 0 0.10000003 0
		 0.19999999 0 0.30000001 0 0.39999998 0 0.5 0 0.60000002 0 0.70000005 0 0.79999995
		 0 0.9000001 0 1 0 0 0.10000003 0.10000003 0.10000003 0.19999999 0.10000003 0.30000001
		 0.10000003 0.39999998 0.10000003 0.5 0.10000003 0.60000002 0.10000003 0.70000005
		 0.10000003 0.79999995 0.10000003 0.9000001 0.10000003 1 0.10000003 0 0.19999999 0.10000003
		 0.19999999 0.19999999 0.19999999 0.30000001 0.19999999 0.39999998 0.19999999 0.5
		 0.19999999 0.60000002 0.19999999 0.70000005 0.19999999 0.79999995 0.19999999 0.9000001
		 0.19999999 1 0.19999999 0 0.30000001 0.10000003 0.30000001 0.19999999 0.30000001
		 0.30000001 0.30000001 0.39999998 0.30000001 0.5 0.30000001 0.60000002 0.30000001
		 0.70000005 0.30000001 0.79999995 0.30000001 0.9000001 0.30000001 1 0.30000001 0 0.39999998
		 0.10000003 0.39999998 0.19999999 0.39999998 0.30000001 0.39999998 0.39999998 0.39999998
		 0.5 0.39999998 0.60000002 0.39999998 0.70000005 0.39999998 0.79999995 0.39999998
		 0.9000001 0.39999998 1 0.39999998 0 0.5 0.10000003 0.5 0.19999999 0.5 0.30000001
		 0.5 0.39999998 0.5 0.5 0.5 0.60000002 0.5 0.70000005 0.5 0.79999995 0.5 0.9000001
		 0.5 1 0.5 0 0.60000002 0.10000003 0.60000002 0.19999999 0.60000002 0.30000001 0.60000002
		 0.39999998 0.60000002 0.5 0.60000002 0.60000002 0.60000002 0.70000005 0.60000002
		 0.79999995 0.60000002 0.9000001 0.60000002 1 0.60000002 0 0.70000005 0.10000003 0.70000005
		 0.19999999 0.70000005 0.30000001 0.70000005 0.39999998 0.70000005 0.5 0.70000005
		 0.60000002 0.70000005 0.70000005 0.70000005 0.79999995 0.70000005 0.9000001 0.70000005
		 1 0.70000005 0 0.79999995 0.10000003 0.79999995 0.19999999 0.79999995 0.30000001
		 0.79999995 0.39999998 0.79999995 0.5 0.79999995 0.60000002 0.79999995 0.70000005
		 0.79999995 0.79999995 0.79999995 0.9000001 0.79999995 1 0.79999995 0 0.9000001 0.10000003
		 0.9000001 0.19999999 0.9000001 0.30000001 0.9000001 0.39999998 0.9000001 0.5 0.9000001
		 0.60000002 0.9000001 0.70000005 0.9000001 0.79999995 0.9000001 0.9000001 0.9000001
		 1 0.9000001 0 1 0.10000003 1 0.19999999 1 0.30000001 1 0.39999998 1 0.5 1 0.60000002
		 1 0.70000005 1 0.79999995 1 0.9000001 1 1 1;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 121 ".pt[0:120]" -type "float3"  0.5 -4.4408921e-16 4.5 0.89999998 
		-4.4408921e-16 4.5 1.3 -4.4408921e-16 4.5 1.7 -4.4408921e-16 4.5 2.0999999 -4.4408921e-16 
		4.5 2.5 -4.4408921e-16 4.5 2.9000001 -4.4408921e-16 4.5 3.3 -4.4408921e-16 4.5 3.7 
		-4.4408921e-16 4.5 4.0999999 -4.4408921e-16 4.5 4.5 -4.4408921e-16 4.5 0.5 -3.5527137e-16 
		4.0999999 0.89999998 -3.5527137e-16 4.0999999 1.3 -3.5527137e-16 4.0999999 1.7 -3.5527137e-16 
		4.0999999 2.0999999 -3.5527137e-16 4.0999999 2.5 -3.5527137e-16 4.0999999 2.9000001 
		-3.5527137e-16 4.0999999 3.3 -3.5527137e-16 4.0999999 3.7 -3.5527137e-16 4.0999999 
		4.0999999 -3.5527137e-16 4.0999999 4.5 -3.5527137e-16 4.0999999 0.5 -2.6645354e-16 
		3.7 0.89999998 -2.6645354e-16 3.7 1.3 -2.6645354e-16 3.7 1.7 -2.6645354e-16 3.7 2.0999999 
		-2.6645354e-16 3.7 2.5 -2.6645354e-16 3.7 2.9000001 -2.6645354e-16 3.7 3.3 -2.6645354e-16 
		3.7 3.7 -2.6645354e-16 3.7 4.0999999 -2.6645354e-16 3.7 4.5 -2.6645354e-16 3.7 0.5 
		-1.7763569e-16 3.3 0.89999998 -1.7763569e-16 3.3 1.3 -1.7763569e-16 3.3 1.7 -1.7763569e-16 
		3.3 2.0999999 -1.7763569e-16 3.3 2.5 -1.7763569e-16 3.3 2.9000001 -1.7763569e-16 
		3.3 3.3 -1.7763569e-16 3.3 3.7 -1.7763569e-16 3.3 4.0999999 -1.7763569e-16 3.3 4.5 
		-1.7763569e-16 3.3 0.5 -8.8817843e-17 2.9000001 0.89999998 -8.8817843e-17 2.9000001 
		1.3 -8.8817843e-17 2.9000001 1.7 -8.8817843e-17 2.9000001 2.0999999 -8.8817843e-17 
		2.9000001 2.5 -8.8817843e-17 2.9000001 2.9000001 -8.8817843e-17 2.9000001 3.3 -8.8817843e-17 
		2.9000001 3.7 -8.8817843e-17 2.9000001 4.0999999 -8.8817843e-17 2.9000001 4.5 -8.8817843e-17 
		2.9000001 0.5 0 2.5 0.89999998 0 2.5 1.3 0 2.5 1.7 0 2.5 2.0999999 0 2.5 2.5 0 2.5 
		2.9000001 0 2.5 3.3 0 2.5 3.7 0 2.5 4.0999999 0 2.5 4.5 0 2.5 0.5 8.8817843e-17 2.0999999 
		0.89999998 8.8817843e-17 2.0999999 1.3 8.8817843e-17 2.0999999 1.7 8.8817843e-17 
		2.0999999 2.0999999 8.8817843e-17 2.0999999 2.5 8.8817843e-17 2.0999999 2.9000001 
		8.8817843e-17 2.0999999 3.3 8.8817843e-17 2.0999999 3.7 8.8817843e-17 2.0999999 4.0999999 
		8.8817843e-17 2.0999999 4.5 8.8817843e-17 2.0999999 0.5 1.7763569e-16 1.7 0.89999998 
		1.7763569e-16 1.7 1.3 1.7763569e-16 1.7 1.7 1.7763569e-16 1.7 2.0999999 1.7763569e-16 
		1.7 2.5 1.7763569e-16 1.7 2.9000001 1.7763569e-16 1.7 3.3 1.7763569e-16 1.7 3.7 1.7763569e-16 
		1.7 4.0999999 1.7763569e-16 1.7 4.5 1.7763569e-16 1.7 0.5 2.6645354e-16 1.3 0.89999998 
		2.6645354e-16 1.3 1.3 2.6645354e-16 1.3 1.7 2.6645354e-16 1.3 2.0999999 2.6645354e-16 
		1.3 2.5 2.6645354e-16 1.3 2.9000001 2.6645354e-16 1.3 3.3 2.6645354e-16 1.3 3.7 2.6645354e-16 
		1.3 4.0999999 2.6645354e-16 1.3 4.5 2.6645354e-16 1.3 0.5 3.5527137e-16 0.89999998 
		0.89999998 3.5527137e-16 0.89999998 1.3 3.5527137e-16 0.89999998 1.7 3.5527137e-16 
		0.89999998 2.0999999 3.5527137e-16 0.89999998 2.5 3.5527137e-16 0.89999998 2.9000001 
		3.5527137e-16 0.89999998 3.3 3.5527137e-16 0.89999998 3.7 3.5527137e-16 0.89999998 
		4.0999999 3.5527137e-16 0.89999998 4.5 3.5527137e-16 0.89999998 0.5 4.4408921e-16 
		0.5 0.89999998 4.4408921e-16 0.5 1.3 4.4408921e-16 0.5 1.7 4.4408921e-16 0.5 2.0999999 
		4.4408921e-16 0.5 2.5 4.4408921e-16 0.5 2.9000001 4.4408921e-16 0.5 3.3 4.4408921e-16 
		0.5 3.7 4.4408921e-16 0.5 4.0999999 4.4408921e-16 0.5 4.5 4.4408921e-16 0.5;
	setAttr -s 121 ".vt[0:120]"  -0.5 -1.110223e-16 0.5 -0.40000001 -1.110223e-16 0.5
		 -0.30000001 -1.110223e-16 0.5 -0.2 -1.110223e-16 0.5 -0.1 -1.110223e-16 0.5 0 -1.110223e-16 0.5
		 0.1 -1.110223e-16 0.5 0.2 -1.110223e-16 0.5 0.30000001 -1.110223e-16 0.5 0.40000001 -1.110223e-16 0.5
		 0.5 -1.110223e-16 0.5 -0.5 -8.8817843e-17 0.40000001 -0.40000001 -8.8817843e-17 0.40000001
		 -0.30000001 -8.8817843e-17 0.40000001 -0.2 -8.8817843e-17 0.40000001 -0.1 -8.8817843e-17 0.40000001
		 0 -8.8817843e-17 0.40000001 0.1 -8.8817843e-17 0.40000001 0.2 -8.8817843e-17 0.40000001
		 0.30000001 -8.8817843e-17 0.40000001 0.40000001 -8.8817843e-17 0.40000001 0.5 -8.8817843e-17 0.40000001
		 -0.5 -6.6613384e-17 0.30000001 -0.40000001 -6.6613384e-17 0.30000001 -0.30000001 -6.6613384e-17 0.30000001
		 -0.2 -6.6613384e-17 0.30000001 -0.1 -6.6613384e-17 0.30000001 0 -6.6613384e-17 0.30000001
		 0.1 -6.6613384e-17 0.30000001 0.2 -6.6613384e-17 0.30000001 0.30000001 -6.6613384e-17 0.30000001
		 0.40000001 -6.6613384e-17 0.30000001 0.5 -6.6613384e-17 0.30000001 -0.5 -4.4408922e-17 0.2
		 -0.40000001 -4.4408922e-17 0.2 -0.30000001 -4.4408922e-17 0.2 -0.2 -4.4408922e-17 0.2
		 -0.1 -4.4408922e-17 0.2 0 -4.4408922e-17 0.2 0.1 -4.4408922e-17 0.2 0.2 -4.4408922e-17 0.2
		 0.30000001 -4.4408922e-17 0.2 0.40000001 -4.4408922e-17 0.2 0.5 -4.4408922e-17 0.2
		 -0.5 -2.2204461e-17 0.1 -0.40000001 -2.2204461e-17 0.1 -0.30000001 -2.2204461e-17 0.1
		 -0.2 -2.2204461e-17 0.1 -0.1 -2.2204461e-17 0.1 0 -2.2204461e-17 0.1 0.1 -2.2204461e-17 0.1
		 0.2 -2.2204461e-17 0.1 0.30000001 -2.2204461e-17 0.1 0.40000001 -2.2204461e-17 0.1
		 0.5 -2.2204461e-17 0.1 -0.5 0 0 -0.40000001 0 0 -0.30000001 0 0 -0.2 0 0 -0.1 0 0
		 0 0 0 0.1 0 0 0.2 0 0 0.30000001 0 0 0.40000001 0 0 0.5 0 0 -0.5 2.2204461e-17 -0.1
		 -0.40000001 2.2204461e-17 -0.1 -0.30000001 2.2204461e-17 -0.1 -0.2 2.2204461e-17 -0.1
		 -0.1 2.2204461e-17 -0.1 0 2.2204461e-17 -0.1 0.1 2.2204461e-17 -0.1 0.2 2.2204461e-17 -0.1
		 0.30000001 2.2204461e-17 -0.1 0.40000001 2.2204461e-17 -0.1 0.5 2.2204461e-17 -0.1
		 -0.5 4.4408922e-17 -0.2 -0.40000001 4.4408922e-17 -0.2 -0.30000001 4.4408922e-17 -0.2
		 -0.2 4.4408922e-17 -0.2 -0.1 4.4408922e-17 -0.2 0 4.4408922e-17 -0.2 0.1 4.4408922e-17 -0.2
		 0.2 4.4408922e-17 -0.2 0.30000001 4.4408922e-17 -0.2 0.40000001 4.4408922e-17 -0.2
		 0.5 4.4408922e-17 -0.2 -0.5 6.6613384e-17 -0.30000001 -0.40000001 6.6613384e-17 -0.30000001
		 -0.30000001 6.6613384e-17 -0.30000001 -0.2 6.6613384e-17 -0.30000001 -0.1 6.6613384e-17 -0.30000001
		 0 6.6613384e-17 -0.30000001 0.1 6.6613384e-17 -0.30000001 0.2 6.6613384e-17 -0.30000001
		 0.30000001 6.6613384e-17 -0.30000001 0.40000001 6.6613384e-17 -0.30000001 0.5 6.6613384e-17 -0.30000001
		 -0.5 8.8817843e-17 -0.40000001 -0.40000001 8.8817843e-17 -0.40000001 -0.30000001 8.8817843e-17 -0.40000001
		 -0.2 8.8817843e-17 -0.40000001 -0.1 8.8817843e-17 -0.40000001 0 8.8817843e-17 -0.40000001
		 0.1 8.8817843e-17 -0.40000001 0.2 8.8817843e-17 -0.40000001 0.30000001 8.8817843e-17 -0.40000001
		 0.40000001 8.8817843e-17 -0.40000001 0.5 8.8817843e-17 -0.40000001 -0.5 1.110223e-16 -0.5
		 -0.40000001 1.110223e-16 -0.5 -0.30000001 1.110223e-16 -0.5 -0.2 1.110223e-16 -0.5
		 -0.1 1.110223e-16 -0.5 0 1.110223e-16 -0.5 0.1 1.110223e-16 -0.5 0.2 1.110223e-16 -0.5
		 0.30000001 1.110223e-16 -0.5 0.40000001 1.110223e-16 -0.5 0.5 1.110223e-16 -0.5;
	setAttr -s 220 ".ed";
	setAttr ".ed[0:165]"  0 1 0 0 11 0 1 2 0 1 12 1 2 3 0 2 13 1 3 4 0 3 14 1
		 4 5 0 4 15 1 5 6 0 5 16 1 6 7 0 6 17 1 7 8 0 7 18 1 8 9 0 8 19 1 9 10 0 9 20 1 10 21 0
		 11 12 1 11 22 0 12 13 1 12 23 1 13 14 1 13 24 1 14 15 1 14 25 1 15 16 1 15 26 1 16 17 1
		 16 27 1 17 18 1 17 28 1 18 19 1 18 29 1 19 20 1 19 30 1 20 21 1 20 31 1 21 32 0 22 23 1
		 22 33 0 23 24 1 23 34 1 24 25 1 24 35 1 25 26 1 25 36 1 26 27 1 26 37 1 27 28 1 27 38 1
		 28 29 1 28 39 1 29 30 1 29 40 1 30 31 1 30 41 1 31 32 1 31 42 1 32 43 0 33 34 1 33 44 0
		 34 35 1 34 45 1 35 36 1 35 46 1 36 37 1 36 47 1 37 38 1 37 48 1 38 39 1 38 49 1 39 40 1
		 39 50 1 40 41 1 40 51 1 41 42 1 41 52 1 42 43 1 42 53 1 43 54 0 44 45 1 44 55 0 45 46 1
		 45 56 1 46 47 1 46 57 1 47 48 1 47 58 1 48 49 1 48 59 1 49 50 1 49 60 1 50 51 1 50 61 1
		 51 52 1 51 62 1 52 53 1 52 63 1 53 54 1 53 64 1 54 65 0 55 56 1 55 66 0 56 57 1 56 67 1
		 57 58 1 57 68 1 58 59 1 58 69 1 59 60 1 59 70 1 60 61 1 60 71 1 61 62 1 61 72 1 62 63 1
		 62 73 1 63 64 1 63 74 1 64 65 1 64 75 1 65 76 0 66 67 1 66 77 0 67 68 1 67 78 1 68 69 1
		 68 79 1 69 70 1 69 80 1 70 71 1 70 81 1 71 72 1 71 82 1 72 73 1 72 83 1 73 74 1 73 84 1
		 74 75 1 74 85 1 75 76 1 75 86 1 76 87 0 77 78 1 77 88 0 78 79 1 78 89 1 79 80 1 79 90 1
		 80 81 1 80 91 1 81 82 1 81 92 1 82 83 1 82 93 1 83 84 1 83 94 1 84 85 1 84 95 1 85 86 1
		 85 96 1 86 87 1;
	setAttr ".ed[166:219]" 86 97 1 87 98 0 88 89 1 88 99 0 89 90 1 89 100 1 90 91 1
		 90 101 1 91 92 1 91 102 1 92 93 1 92 103 1 93 94 1 93 104 1 94 95 1 94 105 1 95 96 1
		 95 106 1 96 97 1 96 107 1 97 98 1 97 108 1 98 109 0 99 100 1 99 110 0 100 101 1 100 111 1
		 101 102 1 101 112 1 102 103 1 102 113 1 103 104 1 103 114 1 104 105 1 104 115 1 105 106 1
		 105 116 1 106 107 1 106 117 1 107 108 1 107 118 1 108 109 1 108 119 1 109 120 0 110 111 0
		 111 112 0 112 113 0 113 114 0 114 115 0 115 116 0 116 117 0 117 118 0 118 119 0 119 120 0;
	setAttr -s 100 -ch 400 ".fc[0:99]" -type "polyFaces" 
		f 4 0 3 -22 -2
		mu 0 4 0 1 12 11
		f 4 2 5 -24 -4
		mu 0 4 1 2 13 12
		f 4 4 7 -26 -6
		mu 0 4 2 3 14 13
		f 4 6 9 -28 -8
		mu 0 4 3 4 15 14
		f 4 8 11 -30 -10
		mu 0 4 4 5 16 15
		f 4 10 13 -32 -12
		mu 0 4 5 6 17 16
		f 4 12 15 -34 -14
		mu 0 4 6 7 18 17
		f 4 14 17 -36 -16
		mu 0 4 7 8 19 18
		f 4 16 19 -38 -18
		mu 0 4 8 9 20 19
		f 4 18 20 -40 -20
		mu 0 4 9 10 21 20
		f 4 21 24 -43 -23
		mu 0 4 11 12 23 22
		f 4 23 26 -45 -25
		mu 0 4 12 13 24 23
		f 4 25 28 -47 -27
		mu 0 4 13 14 25 24
		f 4 27 30 -49 -29
		mu 0 4 14 15 26 25
		f 4 29 32 -51 -31
		mu 0 4 15 16 27 26
		f 4 31 34 -53 -33
		mu 0 4 16 17 28 27
		f 4 33 36 -55 -35
		mu 0 4 17 18 29 28
		f 4 35 38 -57 -37
		mu 0 4 18 19 30 29
		f 4 37 40 -59 -39
		mu 0 4 19 20 31 30
		f 4 39 41 -61 -41
		mu 0 4 20 21 32 31
		f 4 42 45 -64 -44
		mu 0 4 22 23 34 33
		f 4 44 47 -66 -46
		mu 0 4 23 24 35 34
		f 4 46 49 -68 -48
		mu 0 4 24 25 36 35
		f 4 48 51 -70 -50
		mu 0 4 25 26 37 36
		f 4 50 53 -72 -52
		mu 0 4 26 27 38 37
		f 4 52 55 -74 -54
		mu 0 4 27 28 39 38
		f 4 54 57 -76 -56
		mu 0 4 28 29 40 39
		f 4 56 59 -78 -58
		mu 0 4 29 30 41 40
		f 4 58 61 -80 -60
		mu 0 4 30 31 42 41
		f 4 60 62 -82 -62
		mu 0 4 31 32 43 42
		f 4 63 66 -85 -65
		mu 0 4 33 34 45 44
		f 4 65 68 -87 -67
		mu 0 4 34 35 46 45
		f 4 67 70 -89 -69
		mu 0 4 35 36 47 46
		f 4 69 72 -91 -71
		mu 0 4 36 37 48 47
		f 4 71 74 -93 -73
		mu 0 4 37 38 49 48
		f 4 73 76 -95 -75
		mu 0 4 38 39 50 49
		f 4 75 78 -97 -77
		mu 0 4 39 40 51 50
		f 4 77 80 -99 -79
		mu 0 4 40 41 52 51
		f 4 79 82 -101 -81
		mu 0 4 41 42 53 52
		f 4 81 83 -103 -83
		mu 0 4 42 43 54 53
		f 4 84 87 -106 -86
		mu 0 4 44 45 56 55
		f 4 86 89 -108 -88
		mu 0 4 45 46 57 56
		f 4 88 91 -110 -90
		mu 0 4 46 47 58 57
		f 4 90 93 -112 -92
		mu 0 4 47 48 59 58
		f 4 92 95 -114 -94
		mu 0 4 48 49 60 59
		f 4 94 97 -116 -96
		mu 0 4 49 50 61 60
		f 4 96 99 -118 -98
		mu 0 4 50 51 62 61
		f 4 98 101 -120 -100
		mu 0 4 51 52 63 62
		f 4 100 103 -122 -102
		mu 0 4 52 53 64 63
		f 4 102 104 -124 -104
		mu 0 4 53 54 65 64
		f 4 105 108 -127 -107
		mu 0 4 55 56 67 66
		f 4 107 110 -129 -109
		mu 0 4 56 57 68 67
		f 4 109 112 -131 -111
		mu 0 4 57 58 69 68
		f 4 111 114 -133 -113
		mu 0 4 58 59 70 69
		f 4 113 116 -135 -115
		mu 0 4 59 60 71 70
		f 4 115 118 -137 -117
		mu 0 4 60 61 72 71
		f 4 117 120 -139 -119
		mu 0 4 61 62 73 72
		f 4 119 122 -141 -121
		mu 0 4 62 63 74 73
		f 4 121 124 -143 -123
		mu 0 4 63 64 75 74
		f 4 123 125 -145 -125
		mu 0 4 64 65 76 75
		f 4 126 129 -148 -128
		mu 0 4 66 67 78 77
		f 4 128 131 -150 -130
		mu 0 4 67 68 79 78
		f 4 130 133 -152 -132
		mu 0 4 68 69 80 79
		f 4 132 135 -154 -134
		mu 0 4 69 70 81 80
		f 4 134 137 -156 -136
		mu 0 4 70 71 82 81
		f 4 136 139 -158 -138
		mu 0 4 71 72 83 82
		f 4 138 141 -160 -140
		mu 0 4 72 73 84 83
		f 4 140 143 -162 -142
		mu 0 4 73 74 85 84
		f 4 142 145 -164 -144
		mu 0 4 74 75 86 85
		f 4 144 146 -166 -146
		mu 0 4 75 76 87 86
		f 4 147 150 -169 -149
		mu 0 4 77 78 89 88
		f 4 149 152 -171 -151
		mu 0 4 78 79 90 89
		f 4 151 154 -173 -153
		mu 0 4 79 80 91 90
		f 4 153 156 -175 -155
		mu 0 4 80 81 92 91
		f 4 155 158 -177 -157
		mu 0 4 81 82 93 92
		f 4 157 160 -179 -159
		mu 0 4 82 83 94 93
		f 4 159 162 -181 -161
		mu 0 4 83 84 95 94
		f 4 161 164 -183 -163
		mu 0 4 84 85 96 95
		f 4 163 166 -185 -165
		mu 0 4 85 86 97 96
		f 4 165 167 -187 -167
		mu 0 4 86 87 98 97
		f 4 168 171 -190 -170
		mu 0 4 88 89 100 99
		f 4 170 173 -192 -172
		mu 0 4 89 90 101 100
		f 4 172 175 -194 -174
		mu 0 4 90 91 102 101
		f 4 174 177 -196 -176
		mu 0 4 91 92 103 102
		f 4 176 179 -198 -178
		mu 0 4 92 93 104 103
		f 4 178 181 -200 -180
		mu 0 4 93 94 105 104
		f 4 180 183 -202 -182
		mu 0 4 94 95 106 105
		f 4 182 185 -204 -184
		mu 0 4 95 96 107 106
		f 4 184 187 -206 -186
		mu 0 4 96 97 108 107
		f 4 186 188 -208 -188
		mu 0 4 97 98 109 108
		f 4 189 192 -211 -191
		mu 0 4 99 100 111 110
		f 4 191 194 -212 -193
		mu 0 4 100 101 112 111
		f 4 193 196 -213 -195
		mu 0 4 101 102 113 112
		f 4 195 198 -214 -197
		mu 0 4 102 103 114 113
		f 4 197 200 -215 -199
		mu 0 4 103 104 115 114
		f 4 199 202 -216 -201
		mu 0 4 104 105 116 115
		f 4 201 204 -217 -203
		mu 0 4 105 106 117 116
		f 4 203 206 -218 -205
		mu 0 4 106 107 118 117
		f 4 205 208 -219 -207
		mu 0 4 107 108 119 118
		f 4 207 209 -220 -209
		mu 0 4 108 109 120 119;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "imagePlane4" -p "Reference";
	rename -uid "8641E5F4-4817-DBE7-98A9-EE96FFE117C6";
	setAttr ".t" -type "double3" 4.5822467295520983 5.5300308729568775 -10 ;
	setAttr ".s" -type "double3" 38.088853548092914 38.088853548092914 17.080203384795023 ;
	setAttr ".rp" -type "double3" 0 7.9225515037251172e-17 5.6843418860808016e-16 ;
	setAttr ".sp" -type "double3" 0 1.7763568394002505e-17 2.8421709430404008e-16 ;
	setAttr ".spt" -type "double3" 0 6.1461946643248664e-17 2.8421709430404008e-16 ;
createNode imagePlane -n "imagePlaneShape4" -p "imagePlane4";
	rename -uid "E5718923-46E6-C204-9F1B-F38C1BF1EB41";
	setAttr -k off ".v";
	setAttr ".fc" 101;
	setAttr ".imn" -type "string" "D:/UnityProjects/Crowd/MayaProject//sourceimages/Doorlock.jpg";
	setAttr ".cov" -type "short2" 6270 4113 ;
	setAttr ".dlc" no;
	setAttr ".w" 0.62700000000000011;
	setAttr ".h" 0.41130000000000005;
	setAttr ".cs" -type "string" "sRGB";
createNode transform -n "imagePlane3" -p "Reference";
	rename -uid "3DAE9ECE-4553-3B12-0FAE-E499249393A3";
	setAttr ".t" -type "double3" -11 5.53 0.95445448419017909 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
	setAttr ".s" -type "double3" 38.089 38.089 2 ;
createNode imagePlane -n "imagePlaneShape3" -p "imagePlane3";
	rename -uid "52D2AA4D-4E59-2DA7-2DC9-E29ACDBCC527";
	setAttr -k off ".v";
	setAttr ".fc" 101;
	setAttr ".imn" -type "string" "D:/UnityProjects/Crowd/MayaProject//sourceimages/Doorlock.jpg";
	setAttr ".cov" -type "short2" 6270 4113 ;
	setAttr ".dlc" no;
	setAttr ".w" 0.62700000000000011;
	setAttr ".h" 0.41130000000000005;
	setAttr ".cs" -type "string" "sRGB";
createNode transform -n "imagePlane2" -p "Reference";
	rename -uid "83E301AC-443D-62C7-AA16-0DBA21032426";
	setAttr ".t" -type "double3" -10 6.3340763413516745 0.23859037467095345 ;
	setAttr ".r" -type "double3" 0 90 0 ;
	setAttr ".s" -type "double3" 41.153 41.153 2 ;
	setAttr ".rpt" -type "double3" -2.6645352591003756e-17 0 -2.3092638912203257e-16 ;
createNode imagePlane -n "imagePlaneShape2" -p "imagePlane2";
	rename -uid "B940E015-487A-11DD-81D4-CCAB4A270714";
	setAttr -k off ".v";
	setAttr ".fc" 101;
	setAttr ".imn" -type "string" "D:/UnityProjects/Crowd/MayaProject//sourceimages/level0WithLine.jpg";
	setAttr ".cov" -type "short2" 4111 3904 ;
	setAttr ".dlc" no;
	setAttr ".w" 0.4111;
	setAttr ".h" 0.3904;
	setAttr ".cs" -type "string" "sRGB";
createNode transform -n "imagePlane1" -p "Reference";
	rename -uid "8A086D4B-4780-AD81-072E-EBA8554C4A02";
	setAttr ".t" -type "double3" -0.80863003339819051 6.3337686149586396 -10 ;
	setAttr ".s" -type "double3" 41.153191462927865 41.153191462927865 18.454345947501292 ;
createNode imagePlane -n "imagePlaneShape1" -p "imagePlane1";
	rename -uid "090C2495-4C11-73DD-F664-C4BCB109BCC2";
	setAttr -k off ".v";
	setAttr ".fc" 101;
	setAttr ".imn" -type "string" "D:/UnityProjects/Crowd/MayaProject//sourceimages/level0WithLine.jpg";
	setAttr ".cov" -type "short2" 4111 3904 ;
	setAttr ".dlc" no;
	setAttr ".w" 0.4111;
	setAttr ".h" 0.3904;
	setAttr ".cs" -type "string" "sRGB";
createNode transform -n "Grid" -p "Reference";
	rename -uid "1C4D6C17-4746-FAD8-F710-A0A5BEEAD944";
	setAttr ".v" no;
createNode transform -n "pCube1" -p "Grid";
	rename -uid "16E79219-4D89-8067-9F6D-D485D27E037C";
	setAttr ".rp" -type "double3" 0 0.5 0 ;
	setAttr ".sp" -type "double3" 0 0.5 0 ;
createNode mesh -n "pCubeShape1" -p "pCube1";
	rename -uid "FC629E3D-4E0A-C0D6-94C6-5D81D482B488";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube2" -p "Grid";
	rename -uid "1BB3E3E6-41E8-4C9E-9CC3-739405AA00DD";
	setAttr ".rp" -type "double3" 1 0.5 0 ;
	setAttr ".sp" -type "double3" 1 0.5 0 ;
createNode mesh -n "pCubeShape2" -p "pCube2";
	rename -uid "406A8377-4971-DDEA-616C-4A93B5F15A64";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[0:7]" -type "float3"  1 0.5 0 1 0.5 0 1 0.5 0 1 
		0.5 0 1 0.5 0 1 0.5 0 1 0.5 0 1 0.5 0;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube3" -p "Grid";
	rename -uid "41F49351-428E-EBBB-EBA5-AB99A00A6C02";
	setAttr ".rp" -type "double3" 2 0.5 0 ;
	setAttr ".sp" -type "double3" 2 0.5 0 ;
createNode mesh -n "pCubeShape3" -p "pCube3";
	rename -uid "3A709A81-42E7-D371-BDCE-2183F5255105";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[0:7]" -type "float3"  2 0.5 0 2 0.5 0 2 0.5 0 2 
		0.5 0 2 0.5 0 2 0.5 0 2 0.5 0 2 0.5 0;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube4" -p "Grid";
	rename -uid "FF0A33A8-4242-5709-27F0-769297F9EA7F";
	setAttr ".rp" -type "double3" 3 0.5 0 ;
	setAttr ".sp" -type "double3" 3 0.5 0 ;
createNode mesh -n "pCubeShape4" -p "pCube4";
	rename -uid "FD7DCDD2-44D4-092E-AB9D-BA95C90F4891";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[0:7]" -type "float3"  3 0.5 0 3 0.5 0 3 0.5 0 3 
		0.5 0 3 0.5 0 3 0.5 0 3 0.5 0 3 0.5 0;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube5" -p "Grid";
	rename -uid "F0024A0A-445E-7774-0EFF-B7B7D1222A1C";
	setAttr ".rp" -type "double3" -1 0.5 0 ;
	setAttr ".sp" -type "double3" -1 0.5 0 ;
createNode mesh -n "pCubeShape5" -p "pCube5";
	rename -uid "9A998989-4660-8966-C393-65811115C481";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[0:7]" -type "float3"  -1 0.5 0 -1 0.5 0 -1 0.5 
		0 -1 0.5 0 -1 0.5 0 -1 0.5 0 -1 0.5 0 -1 0.5 0;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube6" -p "Grid";
	rename -uid "B8EF2B4E-4D3D-A25B-34F4-BBA9317A7090";
	setAttr ".rp" -type "double3" -2 0.5 0 ;
	setAttr ".sp" -type "double3" -2 0.5 0 ;
createNode mesh -n "pCubeShape6" -p "pCube6";
	rename -uid "CA3AFD22-4F28-6C13-D609-AA957621ABCD";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[0:7]" -type "float3"  -2 0.5 0 -2 0.5 0 -2 0.5 
		0 -2 0.5 0 -2 0.5 0 -2 0.5 0 -2 0.5 0 -2 0.5 0;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube7" -p "Grid";
	rename -uid "6F0ADA95-424D-E6A9-99D5-48941CA31DD4";
	setAttr ".rp" -type "double3" -3 0.5 0 ;
	setAttr ".sp" -type "double3" -3 0.5 0 ;
createNode mesh -n "pCubeShape7" -p "pCube7";
	rename -uid "6249FFCC-4744-6FA8-4787-889DC1EB0917";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[0:7]" -type "float3"  -3 0.5 0 -3 0.5 0 -3 0.5 
		0 -3 0.5 0 -3 0.5 0 -3 0.5 0 -3 0.5 0 -3 0.5 0;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube8" -p "Grid";
	rename -uid "6ED086ED-4584-37CA-7DC0-2FA998CDC88B";
	setAttr ".rp" -type "double3" -3 1.5 0 ;
	setAttr ".sp" -type "double3" -3 1.5 0 ;
createNode mesh -n "pCubeShape8" -p "pCube8";
	rename -uid "96374132-41F8-0E5B-38B0-E182330A8CB4";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[0:7]" -type "float3"  -3 1.5 0 -3 1.5 0 -3 1.5 
		0 -3 1.5 0 -3 1.5 0 -3 1.5 0 -3 1.5 0 -3 1.5 0;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube9" -p "Grid";
	rename -uid "081A88D4-4586-87E2-EE04-869370134081";
	setAttr ".rp" -type "double3" -3 2.5 0 ;
	setAttr ".sp" -type "double3" -3 2.5 0 ;
createNode mesh -n "pCubeShape9" -p "pCube9";
	rename -uid "0B216826-49E6-44F5-688F-E38048B302EF";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[0:7]" -type "float3"  -3 2.5 0 -3 2.5 0 -3 2.5 
		0 -3 2.5 0 -3 2.5 0 -3 2.5 0 -3 2.5 0 -3 2.5 0;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube10" -p "Grid";
	rename -uid "6C8D265A-4E26-CF94-27B2-C2B8FC55B717";
	setAttr ".rp" -type "double3" -3 3.5 0 ;
	setAttr ".sp" -type "double3" -3 3.5 0 ;
createNode mesh -n "pCubeShape10" -p "pCube10";
	rename -uid "2330BFFC-4059-EA05-1ED4-889765F7CDE1";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[0:7]" -type "float3"  -3 3.5 0 -3 3.5 0 -3 3.5 
		0 -3 3.5 0 -3 3.5 0 -3 3.5 0 -3 3.5 0 -3 3.5 0;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube11" -p "Grid";
	rename -uid "355DE35C-4349-F2AA-306F-74A3BAAEEAAD";
	setAttr ".rp" -type "double3" -3 4.5 0 ;
	setAttr ".sp" -type "double3" -3 4.5 0 ;
createNode mesh -n "pCubeShape11" -p "pCube11";
	rename -uid "DCD3916C-4AA1-B041-B7CA-1897BEA27E04";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[0:7]" -type "float3"  -3 4.5 0 -3 4.5 0 -3 4.5 
		0 -3 4.5 0 -3 4.5 0 -3 4.5 0 -3 4.5 0 -3 4.5 0;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube12" -p "Grid";
	rename -uid "F0317156-41D9-DAAB-62C8-DEA657D6FF53";
	setAttr ".rp" -type "double3" -3 5.5 0 ;
	setAttr ".sp" -type "double3" -3 5.5 0 ;
createNode mesh -n "pCubeShape12" -p "pCube12";
	rename -uid "A1FA1912-46D1-519E-D2A9-F093DC6929F3";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[0:7]" -type "float3"  -3 5.5 0 -3 5.5 0 -3 5.5 
		0 -3 5.5 0 -3 5.5 0 -3 5.5 0 -3 5.5 0 -3 5.5 0;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube13" -p "Grid";
	rename -uid "E9874516-4462-2BBE-613D-049FF27E8112";
	setAttr ".rp" -type "double3" -3 6.5 0 ;
	setAttr ".sp" -type "double3" -3 6.5 0 ;
createNode mesh -n "pCubeShape13" -p "pCube13";
	rename -uid "6D8C34CD-4637-D88D-7606-94BFF128E457";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[0:7]" -type "float3"  -3 6.5 0 -3 6.5 0 -3 6.5 
		0 -3 6.5 0 -3 6.5 0 -3 6.5 0 -3 6.5 0 -3 6.5 0;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube14" -p "Grid";
	rename -uid "8ECC48A4-476B-C951-531E-E7874C8D8433";
	setAttr ".rp" -type "double3" -3 7.5 0 ;
	setAttr ".sp" -type "double3" -3 7.5 0 ;
createNode mesh -n "pCubeShape14" -p "pCube14";
	rename -uid "87422B33-46DE-C1F5-E6D0-8195919F50F9";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[0:7]" -type "float3"  -3 7.5 0 -3 7.5 0 -3 7.5 
		0 -3 7.5 0 -3 7.5 0 -3 7.5 0 -3 7.5 0 -3 7.5 0;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "persp1";
	rename -uid "462A4928-4BA0-0F83-B544-6E85BB0CF26A";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0.016147637963295373 0.33836147308349596 -0.075574842763207459 ;
	setAttr ".rp" -type "double3" 1.2212453270876722e-17 -7.105427357601002e-17 1.4155343563970746e-17 ;
	setAttr ".rpt" -type "double3" -3.8647600492834752e-16 1.7329817699628649e-16 3.8512677003688743e-16 ;
createNode camera -n "persp1Shape" -p "persp1";
	rename -uid "04FDA84B-4E5C-2917-F749-ABBE464276C1";
	setAttr -k off ".v" no;
	setAttr ".pze" yes;
	setAttr ".fl" 34.999999999999979;
	setAttr ".ncp" 0.001;
	setAttr ".fcp" 100;
	setAttr ".fd" 0.05;
	setAttr ".coi" 0.012506831812598564;
	setAttr ".ow" 0.1;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" 1.6147637963294983 33.836147308349609 -8.8081674575805664 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
	setAttr ".ai_translator" -type "string" "perspective";
createNode transform -n "Meshes";
	rename -uid "702F3B2F-4386-91EC-504C-4A9782F3D515";
createNode transform -n "Outter" -p "Meshes";
	rename -uid "23CF0E9A-4C31-5CE5-50ED-B698D4FF95C7";
	setAttr ".v" no;
createNode transform -n "pCube15" -p "Outter";
	rename -uid "D4671B13-43AA-03F0-1CE0-BE8964AAE90D";
	setAttr ".t" -type "double3" 0 0 -2 ;
	setAttr ".s" -type "double3" 7 0.1 4 ;
createNode mesh -n "pCubeShape15" -p "pCube15";
	rename -uid "806E65F3-4D93-44E1-71FC-D38FE2271F1D";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube16" -p "Outter";
	rename -uid "34AA55C9-40BF-BE57-BB5A-3885900E3430";
	setAttr ".t" -type "double3" 0 8 -2 ;
	setAttr ".s" -type "double3" 7 0.1 4 ;
createNode mesh -n "pCubeShape16" -p "pCube16";
	rename -uid "A1788F39-4F84-AA69-79D6-6BAA963CD4BE";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube17" -p "Outter";
	rename -uid "39222095-4FF8-47D2-4393-368DC582A403";
	setAttr ".t" -type "double3" 3.5 4 -2 ;
	setAttr ".r" -type "double3" 0 0 -90 ;
	setAttr ".s" -type "double3" 8 0.1 4 ;
createNode mesh -n "pCubeShape17" -p "pCube17";
	rename -uid "BCA2F98A-4735-5EDF-A2D2-26AB79C1172B";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube18" -p "Outter";
	rename -uid "C498CFB7-4BC1-70AC-4213-1CA8281C72E4";
	setAttr ".t" -type "double3" -3.5 4 -2 ;
	setAttr ".r" -type "double3" 0 0 -90 ;
	setAttr ".s" -type "double3" 8 0.1 4 ;
createNode mesh -n "pCubeShape18" -p "pCube18";
	rename -uid "DAD9C929-4B42-39B7-B011-458FD66A737A";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube19" -p "Outter";
	rename -uid "4F5EF364-4459-BDCD-62DB-F6B34AD2D181";
	setAttr ".t" -type "double3" 0 4 -4 ;
	setAttr ".r" -type "double3" 90 0 0 ;
	setAttr ".s" -type "double3" 7 0.1 8 ;
createNode mesh -n "pCubeShape19" -p "pCube19";
	rename -uid "3AC7C01E-4453-D627-8B83-6E9FD7E25016";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "PaperCrane";
	rename -uid "FD4A4B4E-4F67-CC89-4B4A-ACB853186299";
	setAttr ".t" -type "double3" -3.1674712333488482 1.0688302163034262 -1.8917910494806587 ;
	setAttr ".r" -type "double3" 0 -90 0 ;
	setAttr ".s" -type "double3" 5.2740584652811702 0.016384223401971088 4.9364515747173652 ;
	setAttr ".rp" -type "double3" 0.75463226318359078 0 0 ;
	setAttr ".sp" -type "double3" 0.10000000125649888 0 0 ;
	setAttr ".spt" -type "double3" 0.65463226192709467 0 0 ;
createNode mesh -n "PaperCraneShape" -p "PaperCrane";
	rename -uid "6ECCA43E-473F-86A0-16F0-F1A9DC65A7F0";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5249999612569809 0.62499997019767761 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 24 ".pt";
	setAttr ".pt[7]" -type "float3" 0.10608461 -12.827584 0 ;
	setAttr ".pt[13]" -type "float3" -0.10608461 -12.827584 0 ;
	setAttr ".pt[32]" -type "float3" 0.10608461 -12.827584 0 ;
	setAttr ".pt[38]" -type "float3" -0.10608461 -12.827584 0 ;
	setAttr ".pt[44]" -type "float3" 0.033127237 0 0 ;
	setAttr ".pt[45]" -type "float3" 0.033127077 0 0 ;
	setAttr ".pt[46]" -type "float3" -0.033127066 0 0 ;
	setAttr ".pt[47]" -type "float3" -0.033127237 0 0 ;
	setAttr ".pt[48]" -type "float3" 0.033127237 0 0 ;
	setAttr ".pt[49]" -type "float3" 0.033126563 0 0 ;
	setAttr ".pt[50]" -type "float3" -0.033126567 0 0 ;
	setAttr ".pt[51]" -type "float3" -0.033127237 0 0 ;
	setAttr ".pt[52]" -type "float3" 0.029285712 0 0 ;
	setAttr ".pt[53]" -type "float3" -0.029285695 0 0 ;
	setAttr ".pt[54]" -type "float3" 0.029186316 0 0 ;
	setAttr ".pt[55]" -type "float3" -0.029186307 0 0 ;
	setAttr ".pt[56]" -type "float3" 0 0 1.1920929e-09 ;
	setAttr ".pt[57]" -type "float3" 0 0 1.1920929e-09 ;
	setAttr ".pt[58]" -type "float3" 0 0 1.1920929e-09 ;
	setAttr ".pt[59]" -type "float3" 0 0 1.1920929e-09 ;
	setAttr ".pt[60]" -type "float3" 0 0 1.1920929e-09 ;
	setAttr ".pt[61]" -type "float3" 0 0.7277047 0.009831042 ;
	setAttr ".pt[62]" -type "float3" 0 0 1.1920929e-09 ;
	setAttr ".pt[63]" -type "float3" 0 0 1.1920929e-09 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "LockShell";
	rename -uid "46115BBA-44D3-C66D-224F-BD9F8369979C";
	setAttr ".t" -type "double3" 0 4.6336229023411271 -2.1019754928557841 ;
	setAttr ".s" -type "double3" 7.4342347496015782 10.853876682068021 4.1928441602902531 ;
createNode mesh -n "LockShellShape" -p "LockShell";
	rename -uid "5F1AAED2-4559-E8AA-8E83-8AA6F108718D";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.41619610786437988 0.1666666567325592 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 76 ".pt";
	setAttr ".pt[0]" -type "float3" -0.02200895 0 0 ;
	setAttr ".pt[1]" -type "float3" 0.018726943 0 0 ;
	setAttr ".pt[2]" -type "float3" -0.02200895 0 0 ;
	setAttr ".pt[3]" -type "float3" 0.020259051 0 0 ;
	setAttr ".pt[4]" -type "float3" -0.02200895 0 -0.12972338 ;
	setAttr ".pt[5]" -type "float3" 0.020259051 0 -0.12972338 ;
	setAttr ".pt[6]" -type "float3" -0.018042026 0 -0.12972338 ;
	setAttr ".pt[7]" -type "float3" -0.018042026 0 -0.12972338 ;
	setAttr ".pt[8]" -type "float3" 0.014759979 0 -0.12972338 ;
	setAttr ".pt[9]" -type "float3" -0.02200895 0 -0.12972338 ;
	setAttr ".pt[10]" -type "float3" 0.018726943 0 -0.12972338 ;
	setAttr ".pt[11]" -type "float3" 0.014759979 0 -0.12972338 ;
	setAttr ".pt[12]" -type "float3" 0 0 -0.12972338 ;
	setAttr ".pt[13]" -type "float3" 0 0 -0.12972338 ;
	setAttr ".pt[14]" -type "float3" 0.014181495 0 -0.12972338 ;
	setAttr ".pt[15]" -type "float3" 0.014181495 0 -0.12972338 ;
	setAttr ".pt[16]" -type "float3" 0.018726861 0 -0.12972338 ;
	setAttr ".pt[17]" -type "float3" -0.022008847 0 -0.12972338 ;
	setAttr ".pt[18]" -type "float3" 0.020259051 0 -0.12972338 ;
	setAttr ".pt[19]" -type "float3" 0.020259051 0 0 ;
	setAttr ".pt[20]" -type "float3" 0.023541076 0 -0.12972338 ;
	setAttr ".pt[21]" -type "float3" 0.023541076 0 0 ;
	setAttr ".pt[22]" -type "float3" 0.023541076 0 -0.12972338 ;
	setAttr ".pt[23]" -type "float3" 0.023541076 0 0 ;
	setAttr ".pt[24]" -type "float3" 0.023541076 0 -0.037251201 ;
	setAttr ".pt[25]" -type "float3" 0.023541076 0 -0.037251201 ;
	setAttr ".pt[26]" -type "float3" 0.023541076 0 0.034385726 ;
	setAttr ".pt[27]" -type "float3" 0.023541076 0 0.034385726 ;
	setAttr ".pt[28]" -type "float3" 0.018726861 0 0.034385726 ;
	setAttr ".pt[29]" -type "float3" 0.018726861 0 0.034385726 ;
	setAttr ".pt[30]" -type "float3" 0.018726861 0 -0.037251201 ;
	setAttr ".pt[31]" -type "float3" 0.018726861 0 -0.037251201 ;
	setAttr ".pt[32]" -type "float3" -0.023092344 0 0 ;
	setAttr ".pt[33]" -type "float3" -0.023541076 0 0 ;
	setAttr ".pt[34]" -type "float3" -0.023092344 0 -0.12972338 ;
	setAttr ".pt[35]" -type "float3" -0.023541076 0 -0.12972338 ;
	setAttr ".pt[36]" -type "float3" 0.019810351 0 -0.12972338 ;
	setAttr ".pt[37]" -type "float3" 0.020259051 0 -0.12972338 ;
	setAttr ".pt[38]" -type "float3" -0.021560252 0 0 ;
	setAttr ".pt[39]" -type "float3" -0.022008847 0 0 ;
	setAttr ".pt[40]" -type "float3" -0.020476921 0 0 ;
	setAttr ".pt[41]" -type "float3" -0.022008847 0 0 ;
	setAttr ".pt[42]" -type "float3" -0.021560252 0 0 ;
	setAttr ".pt[43]" -type "float3" -0.020476921 0 0 ;
	setAttr ".pt[44]" -type "float3" -0.020476921 0 0 ;
	setAttr ".pt[45]" -type "float3" 0.018278198 0 0 ;
	setAttr ".pt[46]" -type "float3" 0.017194901 0 0 ;
	setAttr ".pt[47]" -type "float3" 0.018726861 0 0 ;
	setAttr ".pt[48]" -type "float3" 0.018726861 0 0 ;
	setAttr ".pt[49]" -type "float3" 0.017194901 0 0 ;
	setAttr ".pt[50]" -type "float3" 0.018278198 0 0 ;
	setAttr ".pt[51]" -type "float3" 0.019810351 0 0 ;
	setAttr ".pt[52]" -type "float3" 0.020259051 0 0 ;
	setAttr ".pt[53]" -type "float3" -0.023092344 0 0 ;
	setAttr ".pt[54]" -type "float3" -0.023541076 0 0 ;
	setAttr ".pt[55]" -type "float3" -0.023092344 0 -0.12972338 ;
	setAttr ".pt[56]" -type "float3" -0.023541076 0 -0.12972338 ;
	setAttr ".pt[57]" -type "float3" 0.018278198 0 -0.12972338 ;
	setAttr ".pt[58]" -type "float3" 0.017194901 0 -0.12972338 ;
	setAttr ".pt[59]" -type "float3" -0.021560252 0 -0.12972338 ;
	setAttr ".pt[60]" -type "float3" -0.020476921 0 -0.12972338 ;
	setAttr ".pt[61]" -type "float3" -0.021560252 0 -0.12972338 ;
	setAttr ".pt[62]" -type "float3" -0.022008847 0 -0.12972338 ;
	setAttr ".pt[63]" -type "float3" -0.020476921 0 -0.12972338 ;
	setAttr ".pt[64]" -type "float3" 0.018278198 0 -0.12972338 ;
	setAttr ".pt[65]" -type "float3" 0.017194901 0 -0.12972338 ;
	setAttr ".pt[66]" -type "float3" 0.018726861 0 -0.12972338 ;
	setAttr ".pt[67]" -type "float3" 4.7788581e-18 0 -0.12972338 ;
	setAttr ".pt[69]" -type "float3" -0.02200895 0 0 ;
	setAttr ".pt[70]" -type "float3" 4.440892e-18 0 -0.12972338 ;
	setAttr ".pt[72]" -type "float3" -0.020476921 0 -0.12972338 ;
	setAttr ".pt[73]" -type "float3" 4.7788581e-18 0 -0.12972338 ;
	setAttr ".pt[74]" -type "float3" -0.020476921 0 0 ;
	setAttr ".pt[76]" -type "float3" -0.02200895 0 -0.12972338 ;
	setAttr ".pt[77]" -type "float3" -0.02200895 0 0 ;
	setAttr ".pt[78]" -type "float3" 4.440892e-18 0 -0.12972338 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "LockHole";
	rename -uid "210CF2DD-4C21-275E-24A3-FD937E34512D";
	setAttr ".t" -type "double3" 0 3.5015220839606243 -5.2515447300164668 ;
	setAttr ".r" -type "double3" 90 0 0 ;
	setAttr ".s" -type "double3" 2.3350839049201033 0.48174705393536732 2.3350839049201033 ;
createNode mesh -n "LockHoleShape" -p "LockHole";
	rename -uid "BC6144F7-4A20-3242-BEE6-C492C3332E20";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.49999998509883881 0.15624996274709702 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 61 ".pt";
	setAttr ".pt[0]" -type "float3" 0 -0.97121596 -1.7763568e-17 ;
	setAttr ".pt[1]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[2]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[3]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[4]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[5]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[6]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[7]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[8]" -type "float3" 0 -0.97121596 -1.7763568e-17 ;
	setAttr ".pt[9]" -type "float3" 0 -0.97121596 -4.2188474e-17 ;
	setAttr ".pt[10]" -type "float3" 0 -0.97121596 -1.7763568e-17 ;
	setAttr ".pt[11]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[12]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[13]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[14]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[15]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[16]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[17]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[18]" -type "float3" 0 -0.97121596 -1.7763568e-17 ;
	setAttr ".pt[19]" -type "float3" 0 -0.97121596 -4.2188474e-17 ;
	setAttr ".pt[20]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[21]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[22]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[23]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[24]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[25]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[26]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[27]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[28]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[29]" -type "float3" 0 -0.97121596 -4.2188474e-17 ;
	setAttr ".pt[30]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[31]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[32]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[33]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[34]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[35]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[36]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[37]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[38]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[39]" -type "float3" 0 -0.97121596 -4.2188474e-17 ;
	setAttr ".pt[80]" -type "float3" 0 -0.97121596 -1.7763568e-17 ;
	setAttr ".pt[81]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[82]" -type "float3" 0 -0.97121596 -4.2188474e-17 ;
	setAttr ".pt[83]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[84]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[85]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[86]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[87]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[88]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[89]" -type "float3" 0 -0.97121596 -1.7763568e-17 ;
	setAttr ".pt[90]" -type "float3" 0 -0.97121596 -4.2188474e-17 ;
	setAttr ".pt[91]" -type "float3" 0 -0.97121596 -1.7763568e-17 ;
	setAttr ".pt[92]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[93]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[94]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[95]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[96]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[97]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[98]" -type "float3" 0 -0.97121596 0 ;
	setAttr ".pt[99]" -type "float3" 0 -0.97121596 -1.7763568e-17 ;
	setAttr ".pt[100]" -type "float3" 0 -0.97121596 -4.2188474e-17 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube22";
	rename -uid "F8B78599-4111-834E-A332-3A8383A6F5DA";
	setAttr ".t" -type "double3" 2.0507130837384291 3.5002269389138001 -2.3174731063960632 ;
	setAttr ".s" -type "double3" 2.9490578244377228 0.28888886510858341 3.1063272415602889 ;
createNode mesh -n "pCubeShape22" -p "pCube22";
	rename -uid "8F767BDF-4342-A749-6315-FEAC963C1F7F";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube23";
	rename -uid "23319E1D-4EC4-EE04-FBAB-6D8E664A10AD";
	setAttr ".t" -type "double3" 4.9622377368869612 4.9118474381883122 -2.5450259176828172 ;
	setAttr ".s" -type "double3" 2.1925925106954645 2.5 1.7754313847780547 ;
createNode mesh -n "pCubeShape23" -p "pCube23";
	rename -uid "A1AF1DDD-44FE-6076-E210-D08FE1D7D824";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.25 0.125 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 4 ".pt";
	setAttr ".pt[0]" -type "float3" -0.18839528 0 0 ;
	setAttr ".pt[2]" -type "float3" -0.18839528 0 0 ;
	setAttr ".pt[4]" -type "float3" -0.18839528 0 0 ;
	setAttr ".pt[5]" -type "float3" -0.18839528 0 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube24";
	rename -uid "4709FC56-48BD-C809-0155-8E82975C3380";
	setAttr ".t" -type "double3" 0 3.501475830078125 -3.1454408872279571 ;
	setAttr ".s" -type "double3" 0.2333333073126255 1.1973619365363284 4 ;
createNode mesh -n "pCubeShape24" -p "pCube24";
	rename -uid "BD1C5B84-41D0-7257-1555-FBAA056ADDCE";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube25";
	rename -uid "7A1AB681-4B16-7A6D-3412-E18F7A675C81";
	setAttr ".t" -type "double3" 0 0.044234967355927496 -2.5486160376058611 ;
	setAttr ".s" -type "double3" 7.5 0.24400001606165747 4.5 ;
createNode mesh -n "pCubeShape25" -p "pCube25";
	rename -uid "8A58F66B-4754-E5CD-6305-28A14B6BAABF";
	setAttr -k off ".v";
	setAttr -av ".iog[0].og[0].gid";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.50956648588180542 0.4375767707824707 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[8:15]" -type "float3"  0.025356401 0 0.052054986 
		0.025356401 0 0.076249674 0.025356401 0 0.076249674 0.025356401 0 0.052054986 0.04151687 
		0 0.052054986 0.04151687 0 0.076249674 0.04151687 0 0.076249674 0.04151687 0 0.052054986;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube26";
	rename -uid "B12894F0-4162-5CA7-6F4C-13AC411912C2";
	setAttr ".t" -type "double3" -2.4790738868810576 0.057074909702125254 -1.8643321014101433 ;
	setAttr ".s" -type "double3" 1 0.32148147484635048 1.1111111154755693 ;
createNode mesh -n "pCubeShape26" -p "pCube26";
	rename -uid "B93F5A6D-4143-10B8-38DF-E6B6E13D11E3";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.50000001490116119 0.62499998509883881 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube27";
	rename -uid "231FBC0B-4D81-F5C6-4A3B-D8ADC0DEE521";
	setAttr ".t" -type "double3" 2.3391321615765226 1.7369734077345242 -3.5830513256285004 ;
	setAttr ".r" -type "double3" 0 -32.590619079376367 0 ;
	setAttr ".s" -type "double3" 2.2321310237388192 3.2158024929714002 0.2 ;
createNode mesh -n "pCubeShape27" -p "pCube27";
	rename -uid "0F5F6EED-4E6C-6BFD-7D97-D1BAB6660170";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.062499996274709702 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 9 ".pt[26:34]" -type "float3"  -1.6342483e-15 0.051772136 
		1.0459189e-13 -1.6342483e-15 0.051772136 1.0459189e-13 -1.6342483e-15 0.051772136 
		1.0459189e-13 -1.6342483e-15 0.051772136 1.0459189e-13 -1.6342483e-15 0.051772136 
		1.0459189e-13 -1.6342483e-15 0.051772136 1.0459189e-13 -1.6342483e-15 0.051772136 
		1.0459189e-13 -1.6342483e-15 0.051772136 1.0459189e-13 0 0 0;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube28";
	rename -uid "7FA1C920-4D0F-B363-AD63-BE85BFC21F77";
	setAttr ".t" -type "double3" 1.9838093234073204 2.9731980660501187 -2.9766527472283126 ;
	setAttr ".r" -type "double3" 0 -29.999999999999996 0 ;
	setAttr ".s" -type "double3" 0.06736236789738019 0.13503009796199086 1.1095529408740412 ;
createNode mesh -n "pCubeShape28" -p "pCube28";
	rename -uid "1EDD7FE2-4CA1-8BC9-384A-DBA6B49666B1";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.4375 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pSphere1";
	rename -uid "E15AC45D-47F8-D545-6FD4-37A63E8C27F9";
	setAttr ".t" -type "double3" -2.4976727785864661 1.0167649036696118 -1.8917911230288706 ;
	setAttr ".s" -type "double3" 0.91867124857439797 0.47699021008843023 0.91867124857439797 ;
createNode mesh -n "pSphereShape1" -p "pSphere1";
	rename -uid "503FD071-4C45-D53F-FE99-328216E81CB7";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.0625 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 242 ".pt";
	setAttr ".pt[0:165]" -type "float3"  -7.4505804e-11 0.059852172 -5.5879353e-11 
		-1.4901161e-10 0.059852172 -1.1175871e-10 -1.8626451e-11 0.059852172 -7.4505804e-11 
		3.5527136e-17 0.059852172 7.4505804e-11 -1.8626451e-11 0.059852172 -1.4901161e-10 
		3.7252902e-11 0.059852172 -3.7252902e-11 -7.4505804e-11 0.059852172 -3.7252902e-11 
		1.4901161e-10 0.059852172 -3.5527136e-17 7.4505804e-11 0.059852172 -1.8626451e-11 
		-3.7252902e-11 0.059852172 0 -1.8626451e-11 0.059852172 2.2351741e-10 0 0.059852172 
		7.4505804e-11 3.7252902e-11 0.059852172 7.4505804e-11 3.7252902e-11 0.059852172 0 
		7.4505804e-11 0.059852172 3.7252902e-11 -1.4901161e-10 0.059852172 -8.881784e-18 
		2.9802322e-10 0.03101851 -1.4901161e-10 2.9802322e-10 0.03101851 0 0 0.03101851 -5.9604643e-10 
		-5.6843418e-16 0.03101851 5.9604643e-10 1.4901161e-10 0.03101851 -2.9802322e-10 0 
		0.03101851 -2.9802322e-10 -5.9604643e-10 0.03101851 -1.4901161e-10 5.9604643e-10 
		0.03101851 1.4210854e-16 2.9802322e-10 0.03101851 -2.9802322e-10 0 0.03101851 -2.9802322e-10 
		1.4901161e-10 0.03101851 5.9604643e-10 -1.4210854e-16 0.03101851 -2.9802322e-10 -2.9802322e-10 
		0.03101851 2.9802322e-10 2.9802322e-10 0.03101851 0 2.9802322e-10 0.03101851 0 -5.9604643e-10 
		0.03101851 3.5527136e-17 -2.3841857e-09 0 -2.9802322e-10 1.7881393e-09 0 5.9604643e-10 
		5.9604643e-10 0 -1.1920929e-09 2.2737367e-15 0 -1.1920929e-09 8.9406965e-10 0 2.3841857e-09 
		-5.9604643e-10 0 1.7881393e-09 -2.3841857e-09 0 0 0 0 5.6843418e-16 1.1920929e-09 
		0 0 1.1920929e-09 0 1.1920929e-09 -2.9802322e-10 0 2.3841857e-09 0 0 0 -8.9406965e-10 
		0 -1.1920929e-09 0 0 0 -1.1920929e-09 0 0 0 0 -1.4210854e-16 -2.3841857e-09 -1.9073486e-08 
		1.7881393e-09 0 -1.9073486e-08 -1.1920929e-09 0 -1.9073486e-08 2.3841857e-09 0 -1.9073486e-08 
		-2.3841857e-09 0 -1.9073486e-08 0 4.7683715e-09 -1.9073486e-08 0 0 -1.9073486e-08 
		0 0 -1.9073486e-08 1.1368684e-15 0 -1.9073486e-08 1.7881393e-09 -1.1920929e-09 -1.9073486e-08 
		0 5.9604643e-10 -1.9073486e-08 -2.3841857e-09 5.6843418e-16 -1.9073486e-08 2.3841857e-09 
		5.9604643e-10 -1.9073486e-08 2.3841857e-09 2.3841857e-09 -1.9073486e-08 1.1920929e-09 
		0 -1.9073486e-08 -1.1920929e-09 0 -1.9073486e-08 1.4210854e-16 -0.0057934015 4.7683715e-09 
		0.0023997005 -0.0044340827 4.7683715e-09 0.0044340808 -0.0023997102 4.7683715e-09 
		0.005793402 -3.1770031e-09 4.7683715e-09 0.0062707369 0.0023997044 4.7683715e-09 
		0.0057934094 0.0044340743 4.7683715e-09 0.0044340827 0.0057934094 4.7683715e-09 0.0023997098 
		0.0062707351 4.7683715e-09 2.5302853e-09 0.005793409 4.7683715e-09 -0.002399704 0.0044340799 
		4.7683715e-09 -0.0044340794 0.0023997109 4.7683715e-09 -0.0057934048 9.3441188e-10 
		4.7683715e-09 -0.0062707369 -0.0023997079 4.7683715e-09 -0.005793401 -0.0044340785 
		4.7683715e-09 -0.0044340836 -0.0057934104 4.7683715e-09 -0.0023997058 -0.0062707351 
		4.7683715e-09 2.8769498e-10 -0.034248628 0 0.014186221 -0.026212774 0 0.026212746 
		-0.014186263 0 0.034248613 -1.8781348e-08 0 0.037070442 0.01418623 0 0.034248624 
		0.02621275 0 0.026212774 0.034248613 0 0.01418626 0.037070446 0 1.4788064e-08 0.03424862 
		0 -0.014186228 0.026212761 0 -0.02621275 0.014186247 0 -0.034248613 5.5239262e-09 
		0 -0.037070442 -0.014186237 0 -0.03424862 -0.026212759 0 -0.026212757 -0.03424862 
		0 -0.014186239 -0.037070446 0 1.5306381e-09 -0.045965217 0 0.019039391 -0.035180267 
		0 0.035180222 -0.019039437 0 0.045965195 -2.5206523e-08 0 0.049752388 0.019039392 
		0 0.045965225 0.035180233 0 0.035180263 0.045965206 0 0.01903943 0.049752388 0 1.9727924e-08 
		0.04596521 0 -0.019039398 0.035180259 0 -0.035180237 0.019039426 0 -0.045965206 7.4136812e-09 
		0 -0.049752388 -0.019039406 0 -0.045965213 -0.035180245 0 -0.035180248 -0.045965213 
		0 -0.019039411 -0.049752388 0 1.9350854e-09 -0.046865739 0 0.019412396 -0.03586949 
		0 0.035869457 -0.019412439 0 0.046865713 -2.5700345e-08 0 0.050727092 0.0194124 0 
		0.046865731 0.035869461 0 0.035869494 0.04686572 0 0.019412439 0.050727092 0 2.0076511e-08 
		0.04686572 0 -0.019412404 0.035869483 0 -0.035869464 0.019412426 0 -0.046865731 7.5589268e-09 
		0 -0.050727092 -0.019412415 0 -0.046865724 -0.035869475 0 -0.035869479 -0.046865731 
		0 -0.019412415 -0.050727092 0 1.9350854e-09 -0.037714213 0 0.015621712 -0.028865211 
		0 0.028865175 -0.015621752 0 0.037714176 -2.0681806e-08 0 0.040821563 0.015621717 
		0 0.037714206 0.028865185 0 0.028865203 0.037714187 0 0.015621748 0.040821556 0 1.6186652e-08 
		0.037714206 0 -0.015621719 0.028865209 0 -0.028865186 0.015621739 0 -0.037714198 
		6.0828849e-09 0 -0.040821556 -0.015621729 0 -0.037714195 -0.028865194 0 -0.028865192 
		-0.037714198 0 -0.015621734 -0.040821556 0 1.5877264e-09 -0.0086075962 0 0.0035653773 
		-0.0065879668 0 0.0065879668 -0.0035653859 0 0.0086075887 -4.7202557e-09 0 0.0093167908 
		0.0035653783 0 0.0086075962 0.0065879645 0 0.0065879677 0.0086075906 0 0.0035653869 
		0.0093167946 0 3.7166341e-09 0.0086075971 0 -0.0035653787 0.0065879691 0 -0.0065879617 
		0.0035653852 0 -0.008607598 1.3883102e-09 0 -0.0093167908 -0.0035653817 0 -0.0086075924 
		-0.0065879617 0 -0.0065879729 -0.0086075915 0 -0.0035653813 -0.0093167946 0 3.8469025e-10 
		-2.3841857e-09 -0.087714121 0 1.1920929e-09 -0.087714121 1.1920929e-09 0 -0.087714121 
		0 -1.1368684e-15 -0.087714121 -2.3841857e-09 1.1920929e-09 -0.087714121 0 -1.1920929e-09 
		-0.087714121 -1.1920929e-09;
	setAttr ".pt[166:241]" -4.7683715e-09 -0.087714121 0 4.7683715e-09 -0.087714121 
		0 -2.3841857e-09 -0.087714121 -1.1920929e-09 2.3841857e-09 -0.087714121 -1.1920929e-09 
		1.1920929e-09 -0.087714121 -2.3841857e-09 -2.8421709e-16 -0.087714121 2.3841857e-09 
		-1.1920929e-09 -0.087714121 0 2.3841857e-09 -0.087714121 -2.3841857e-09 2.3841857e-09 
		-0.087714121 1.1920929e-09 -4.7683715e-09 -0.087714121 1.4210854e-16 -0.0007474795 
		-0.61032373 0.00030961682 -0.00057209842 -0.61032373 0.00057209673 -0.00030961641 
		-0.61032373 0.00074747665 -4.0990464e-10 -0.61032373 0.00080906547 0.00030961563 
		-0.61032373 0.00074747932 0.00057209434 -0.61032373 0.00057209842 0.00074747665 -0.61032373 
		0.00030961691 0.00080906332 -0.61032373 3.3299188e-10 0.00074747932 -0.61032373 -0.00030961336 
		0.00057209836 -0.61032373 -0.00057209202 0.00030961496 -0.61032373 -0.00074747665 
		1.205599e-10 -0.61032373 -0.00080906547 -0.0003096165 -0.61032373 -0.00074747915 
		-0.00057209213 -0.61032373 -0.00057209708 -0.00074748159 -0.61032373 -0.0003096142 
		-0.00080906332 -0.61032373 4.364744e-11 0 -1.2666923 5.9604643e-10 -3.5762786e-09 
		-1.2666923 0 0 -1.2666923 0 -5.6843418e-16 -1.2666923 0 -1.1920929e-09 -1.2666923 
		0 0 -1.2666923 -1.1920929e-09 0 -1.2666923 -1.1920929e-09 0 -1.2666923 -5.6843418e-16 
		-1.1920929e-09 -1.2666923 0 1.1920929e-09 -1.2666923 -1.1920929e-09 -5.9604643e-10 
		-1.2666923 1.1920929e-09 2.8421709e-16 -1.2666923 -1.1920929e-09 5.9604643e-10 -1.2666923 
		0 0 -1.2666923 0 -1.1920929e-09 -1.2666923 0 0 -1.2666923 -7.1054272e-17 1.1920929e-09 
		-1.5503865 2.9802322e-10 0 -1.5503865 -5.9604643e-10 2.9802322e-10 -1.5503865 0 -2.8421709e-16 
		-1.5503865 -5.9604643e-10 0 -1.5503865 -1.1920929e-09 -5.9604643e-10 -1.5503865 0 
		0 -1.5503865 2.9802322e-10 -5.9604643e-10 -1.5503865 -2.8421709e-16 1.1920929e-09 
		-1.5503865 2.9802322e-10 8.9406965e-10 -1.5503865 -1.1920929e-09 2.9802322e-10 -1.5503865 
		0 2.1316282e-16 -1.5503865 0 0 -1.5503865 0 0 -1.5503865 -8.9406965e-10 0 -1.5503865 
		2.9802322e-10 5.9604643e-10 -1.5503865 7.1054272e-17 2.2351741e-10 -1.6647671 7.4505804e-11 
		-7.4505804e-11 -1.6647671 7.4505804e-11 3.7252902e-11 -1.6647671 7.4505804e-11 0 
		-1.6647671 -7.4505804e-11 3.7252902e-11 -1.6647671 0 0 -1.6647671 7.4505804e-11 7.4505804e-11 
		-1.6647671 0 1.4901161e-10 -1.6647671 -7.1054272e-17 1.4901161e-10 -1.6647671 -3.7252902e-11 
		7.4505804e-11 -1.6647671 7.4505804e-11 3.7252902e-11 -1.6647671 -1.4901161e-10 0 
		-1.6647671 -2.2351741e-10 0 -1.6647671 -1.4901161e-10 0 -1.6647671 1.4901161e-10 
		1.4901161e-10 -1.6647671 7.4505804e-11 -1.4901161e-10 -1.6647671 -3.5527136e-17 0 
		0.028978853 0 0 -1.6990536 0;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube29";
	rename -uid "2ED65A4F-4B2C-1E1B-2AE2-AC9434A1D390";
	setAttr ".t" -type "double3" -1.155975318595873 0.65157811342822014 -1.864 ;
createNode mesh -n "pCubeShape29" -p "pCube29";
	rename -uid "D84B4CE9-40B6-60BE-AB1F-4F81C39A6C6E";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.3333333432674408 0.37499997019767761 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube30";
	rename -uid "DD648BE1-4B8D-1E4F-CFEA-48BDB663853F";
	setAttr ".t" -type "double3" -1.8236897612175136 0.38709070474477736 -3.9671455653121552 ;
	setAttr ".s" -type "double3" 3.7200730809449007 0.448630621820714 1.6594195568177239 ;
createNode mesh -n "pCubeShape30" -p "pCube30";
	rename -uid "7DEDA06F-405A-92D6-50B2-C3A6F7A5AC9A";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.75 0.125 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 22 ".pt";
	setAttr ".pt[0]" -type "float3" 0 0 0.11108763 ;
	setAttr ".pt[1]" -type "float3" 0.069075063 0 0.36145437 ;
	setAttr ".pt[2]" -type "float3" 0 0 0.11108763 ;
	setAttr ".pt[3]" -type "float3" 0.069075063 0 0.36145437 ;
	setAttr ".pt[5]" -type "float3" 0.069075063 0 0 ;
	setAttr ".pt[7]" -type "float3" 0.069075063 0 0 ;
	setAttr ".pt[8]" -type "float3" 0 0 0.46213782 ;
	setAttr ".pt[11]" -type "float3" 0 0 0.46213782 ;
	setAttr ".pt[12]" -type "float3" 0 0 0.4102768 ;
	setAttr ".pt[15]" -type "float3" 0 0 0.4102768 ;
	setAttr ".pt[16]" -type "float3" 0 0 0.3414672 ;
	setAttr ".pt[19]" -type "float3" 0 0 0.3414672 ;
	setAttr ".pt[20]" -type "float3" -3.5527136e-17 0 0.29421422 ;
	setAttr ".pt[23]" -type "float3" -3.5527136e-17 0 0.29421422 ;
	setAttr ".pt[24]" -type "float3" 0 0 0.28954232 ;
	setAttr ".pt[27]" -type "float3" 0 0 0.28954232 ;
	setAttr ".pt[28]" -type "float3" 7.1054272e-17 0 0.31992942 ;
	setAttr ".pt[31]" -type "float3" 7.1054272e-17 0 0.31992942 ;
	setAttr ".pt[32]" -type "float3" 0 0 0.31798857 ;
	setAttr ".pt[35]" -type "float3" 0 0 0.31798857 ;
	setAttr ".pt[36]" -type "float3" 0 0 0.27716154 ;
	setAttr ".pt[39]" -type "float3" 0 0 0.27716154 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube31";
	rename -uid "44DEAFE9-4A23-7E50-0AFC-3785A0A895A1";
	setAttr ".t" -type "double3" 0.27094328174400145 1.8295785581116051 -3.9298027097369483 ;
	setAttr ".s" -type "double3" 1.1689861180197263 2.4803703281593443 0.20000003146074793 ;
createNode mesh -n "pCubeShape31" -p "pCube31";
	rename -uid "1678CCD8-48D3-FC39-DCD0-0ABFEEDE2939";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube32";
	rename -uid "03BE361B-4DAF-0358-0434-AB811AD6BD4B";
	setAttr ".t" -type "double3" -2.5368583343932607 2.2541019735208834 -3.7852469520875274 ;
	setAttr ".s" -type "double3" 1.1689861180197263 2.4803703281593443 0.20000003146074793 ;
createNode mesh -n "pCubeShape32" -p "pCube32";
	rename -uid "E29C0217-471A-6D9A-4668-7FB6046020E5";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube33";
	rename -uid "F01FF512-4C1F-2B65-53AC-2D9E4509A64D";
	setAttr ".t" -type "double3" -0.62105892383910355 1.2848206510565401 -2.8426911936403965 ;
	setAttr ".s" -type "double3" 1.1689861180197263 2.4803703281593443 0.20000003146074793 ;
createNode mesh -n "pCubeShape33" -p "pCube33";
	rename -uid "6896876D-4C82-DAE7-DA66-06A1AA7744F1";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 6 -ch 24 ".fc[0:5]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "pCube34";
	rename -uid "42DECFBB-44E8-FCAD-6CF5-CC882A65799C";
	setAttr ".t" -type "double3" -1.8236897612175136 0.83410552833999474 -4.0451653374005749 ;
	setAttr ".s" -type "double3" 3.7200730809449007 0.448630621820714 1.4462850038233379 ;
createNode mesh -n "pCubeShape34" -p "pCube34";
	rename -uid "38A154CD-4D46-425F-C417-45AF1FF46E7E";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.4861111044883728 0.125 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 14 ".pt";
	setAttr ".pt[0]" -type "float3" 0 0 -0.34389266 ;
	setAttr ".pt[1]" -type "float3" 0 0 -0.34389266 ;
	setAttr ".pt[4]" -type "float3" 0.012259088 0 -0.53664827 ;
	setAttr ".pt[5]" -type "float3" 0.092607953 0 0 ;
	setAttr ".pt[6]" -type "float3" 0.092607953 0 0 ;
	setAttr ".pt[7]" -type "float3" 0.012259088 0 -0.53664827 ;
	setAttr ".pt[8]" -type "float3" 0 0 -0.3677074 ;
	setAttr ".pt[11]" -type "float3" 0 0 -0.3677074 ;
	setAttr ".pt[12]" -type "float3" 0 0 -0.34152395 ;
	setAttr ".pt[15]" -type "float3" 0 0 -0.34152395 ;
	setAttr ".pt[16]" -type "float3" 0 0 -0.37909696 ;
	setAttr ".pt[19]" -type "float3" 0 0 -0.37909696 ;
	setAttr ".pt[20]" -type "float3" 0 0 -0.41112778 ;
	setAttr ".pt[23]" -type "float3" 0 0 -0.41112778 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode mesh -n "polySurfaceShape1" -p "pCube34";
	rename -uid "43CAF6C3-401E-D640-1C24-388A68F19134";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5138888955116272 0.625 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 32 ".uvst[0].uvsp[0:31]" -type "float2" 0.375 0 0.375 0.25
		 0.375 0.5 0.375 0.75 0.375 1 0.125 0 0.125 0.25 0.5138889 0.25 0.5138889 0.5 0.5138889
		 0.75 0.5138889 0 0.5138889 1 0.4861111 0.25 0.4861111 0.5 0.4861111 0.75 0.4861111
		 0 0.4861111 1 0.45833331 0.25 0.45833331 0.5 0.45833331 0.75 0.45833331 0 0.45833331
		 1 0.43055552 0.25 0.43055552 0.5 0.43055552 0.75 0.43055552 0 0.43055552 1 0.40277776
		 0.25 0.40277776 0.5 0.40277776 0.75 0.40277776 0 0.40277776 1;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 24 ".vt[0:23]"  -0.5 -0.5 0.88103271 -0.5 0.5 0.88103271
		 -0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.17178439 0.5 0.52007997 0.20093781 0.5 -0.5 0.20093781 -0.5 -0.5
		 0.17178439 -0.5 0.52007997 0.037427522 0.5 0.62422395 0.060750265 0.5 -0.5 0.060750265 -0.5 -0.5
		 0.037427522 -0.5 0.62422395 -0.096929356 0.5 0.7634269 -0.079437301 0.5 -0.5 -0.079437301 -0.5 -0.5
		 -0.096929356 -0.5 0.7634269 -0.23128624 0.5 0.8703019 -0.21962488 0.5 -0.5 -0.21962488 -0.5 -0.5
		 -0.23128624 -0.5 0.8703019 -0.36564311 0.5 0.93829077 -0.35981244 0.5 -0.5 -0.35981244 -0.5 -0.5
		 -0.36564311 -0.5 0.93829077;
	setAttr -s 44 ".ed[0:43]"  0 23 0 1 20 0 2 21 0 3 22 0 0 1 0 1 2 0 2 3 0
		 3 0 0 4 5 0 5 6 0 6 7 0 7 4 0 8 4 0 9 5 0 8 9 1 10 6 0 9 10 1 11 7 0 10 11 1 11 8 1
		 12 8 0 13 9 0 12 13 1 14 10 0 13 14 1 15 11 0 14 15 1 15 12 1 16 12 0 17 13 0 16 17 1
		 18 14 0 17 18 1 19 15 0 18 19 1 19 16 1 20 16 0 21 17 0 20 21 1 22 18 0 21 22 1 23 19 0
		 22 23 1 23 20 1;
	setAttr -s 21 -ch 84 ".fc[0:20]" -type "polyFaces" 
		f 4 0 43 -2 -5
		mu 0 4 0 30 27 1
		f 4 1 38 -3 -6
		mu 0 4 1 27 28 2
		f 4 2 40 -4 -7
		mu 0 4 2 28 29 3
		f 4 3 42 -1 -8
		mu 0 4 3 29 31 4
		f 4 7 4 5 6
		mu 0 4 5 0 1 6
		f 4 12 8 -14 -15
		mu 0 4 12 7 8 13
		f 4 -17 13 9 -16
		mu 0 4 14 13 8 9
		f 4 -19 15 10 -18
		mu 0 4 16 14 9 11
		f 4 -20 17 11 -13
		mu 0 4 12 15 10 7
		f 4 20 14 -22 -23
		mu 0 4 17 12 13 18
		f 4 -25 21 16 -24
		mu 0 4 19 18 13 14
		f 4 -27 23 18 -26
		mu 0 4 21 19 14 16
		f 4 -28 25 19 -21
		mu 0 4 17 20 15 12
		f 4 28 22 -30 -31
		mu 0 4 22 17 18 23
		f 4 -33 29 24 -32
		mu 0 4 24 23 18 19
		f 4 -35 31 26 -34
		mu 0 4 26 24 19 21
		f 4 -36 33 27 -29
		mu 0 4 22 25 20 17
		f 4 36 30 -38 -39
		mu 0 4 27 22 23 28
		f 4 -41 37 32 -40
		mu 0 4 29 28 23 24
		f 4 -43 39 34 -42
		mu 0 4 31 29 24 26
		f 4 -44 41 35 -37
		mu 0 4 27 30 25 22;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -n "Ladder";
	rename -uid "E40D4746-496E-9BC1-CB1C-ED94CD7AD059";
	setAttr ".t" -type "double3" 3.169232280018365 -0.010539620818097169 -0.14236281850295737 ;
	setAttr ".r" -type "double3" 0 30.142067303093263 0 ;
	setAttr ".s" -type "double3" 0.86059585353404089 0.86059585353404089 0.86059585353404089 ;
	setAttr ".rp" -type "double3" 0 0.13332901000976563 -2.1622552490234375 ;
	setAttr ".sp" -type "double3" 0 0.13332901000976563 -2.1622552490234375 ;
createNode mesh -n "LadderShape" -p "Ladder";
	rename -uid "657ADC47-4113-EA04-2141-1DB9DF68E03C";
	setAttr -k off ".v";
	setAttr ".iog[0].og[0].gcl" -type "componentList" 1 "f[0:77]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 126 ".uvst[0].uvsp[0:125]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.375 0.083333336 0.625 0.083333336 0.625 0.125 0.375
		 0.125 0.375 0.25 0.625 0.25 0.625 0.5 0.375 0.5 0.375 0.625 0.625 0.625 0.625 0.66666663
		 0.375 0.66666663 0.375 0.75 0.625 0.75 0.625 1 0.375 1 0.875 0.083333336 0.875 0.125
		 0.125 0.083333336 0.125 0.125 0.125 0.25 0.875 0.25 0.375 0.125 0.625 0.125 0.625
		 0.25 0.375 0.25 0.625 0.125 0.375 0.125 0.375 0.125 0.625 0.125 0.625 0.125 0.375
		 0.125 0.375 0.083333336 0.625 0.083333336 0.625 0.125 0.375 0.125 0.375 0.25 0.625
		 0.25 0.625 0.5 0.375 0.5 0.375 0.625 0.625 0.625 0.625 0.66666663 0.375 0.66666663
		 0.375 0.75 0.625 0.75 0.625 1 0.375 1 0.875 0.083333336 0.875 0.125 0.125 0.083333336
		 0.125 0.125 0.125 0.25 0.875 0.25 0.375 0.125 0.625 0.125 0.625 0.25 0.375 0.25 0.625
		 0.125 0.375 0.125 0.375 0.125 0.625 0.125 0.625 0.125 0.375 0.125 0.125 0 0.375 0
		 0.375 0.041666672 0.125 0.041666672 0.625 0 0.625 0.041666672 0.875 0 0.875 0.041666672
		 0.375 0.70833331 0.625 0.70833331 0.125 0 0.375 0 0.375 0.041666672 0.125 0.041666672
		 0.625 0 0.625 0.041666672 0.875 0 0.875 0.041666672 0.375 0.70833331 0.625 0.70833331
		 0.375 0 0.625 0 0.625 0.25 0.375 0.25 0.625 0.5 0.375 0.5 0.625 0.75 0.375 0.75 0.625
		 1 0.375 1 0.875 0 0.875 0.25 0.125 0 0.125 0.25 0.375 0 0.625 0 0.625 0.25 0.375
		 0.25 0.625 0.5 0.375 0.5 0.625 0.75 0.375 0.75 0.625 1 0.375 1 0.875 0 0.875 0.25
		 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 84 ".vt[0:83]"  -0.28857157 0.49107784 -1.85593593 0.28857157 0.49107784 -1.85593593
		 -0.28857157 0.54906213 -1.85593593 0.28857157 0.54906213 -1.85593593 -0.28857157 0.54906213 -2.087452412
		 0.28857157 0.54906213 -2.087452412 -0.28857157 0.49107784 -2.087452412 0.28857157 0.49107784 -2.087452412
		 0.28995362 0.13332905 -2.49867439 0.33161071 0.13332905 -2.49867439 0.28995362 1.21690726 -2.29387593
		 0.33161071 1.21690726 -2.29387593 0.28995362 1.21690762 -2.34977102 0.33161071 1.21690762 -2.34977102
		 0.28995362 0.13332912 -2.55450082 0.33161071 0.13332912 -2.55450082 0.28995362 1.10039079 -2.31595922
		 0.28995362 1.10039091 -2.3717854 0.33161071 1.10039091 -2.3717854 0.33161071 1.10039079 -2.31595922
		 0.33161086 1.10039079 -2.25458002 0.28995362 1.10039079 -2.25458002 0.33161086 1.10039079 -2.15984893
		 0.28995362 1.10039079 -2.15984893 0.33161071 1.21690762 -2.20790124 0.28995362 1.21690726 -2.20790124
		 0.33161086 0.133329 -1.86474085 0.28995362 0.133329 -1.86474085 0.33161086 0.133329 -1.77000976
		 0.28995362 0.133329 -1.77000976 -0.33161086 0.13332905 -2.49867439 -0.28995377 0.13332905 -2.49867439
		 -0.33161086 1.21690726 -2.29387593 -0.28995377 1.21690726 -2.29387593 -0.33161086 1.21690762 -2.34977102
		 -0.28995377 1.21690762 -2.34977102 -0.33161086 0.13332912 -2.55450082 -0.28995377 0.13332912 -2.55450082
		 -0.33161086 1.10039079 -2.31595922 -0.33161086 1.10039091 -2.3717854 -0.28995377 1.10039091 -2.3717854
		 -0.28995377 1.10039079 -2.31595922 -0.28995362 1.10039079 -2.25458002 -0.33161086 1.10039079 -2.25458002
		 -0.28995362 1.10039079 -2.15984893 -0.33161086 1.10039079 -2.15984893 -0.28995377 1.21690762 -2.20790124
		 -0.33161086 1.21690726 -2.20790124 -0.28995362 0.133329 -1.86474085 -0.33161086 0.133329 -1.86474085
		 -0.28995362 0.133329 -1.77000976 -0.33161086 0.133329 -1.77000976 -0.33161086 0.4032222 -2.50350761
		 -0.33161086 0.40322199 -2.44768119 -0.28995377 0.40322208 -2.44768119 -0.28995377 0.40322223 -2.50350761
		 -0.33161086 0.5621509 -2.47347951 -0.33161086 0.56215072 -2.41765356 -0.28995377 0.5621509 -2.41765356
		 -0.28995377 0.56215072 -2.47347951 0.28995362 0.40322211 -2.50350761 0.28995362 0.40322199 -2.44768119
		 0.33161086 0.40322208 -2.44768119 0.33161086 0.40322199 -2.50350761 0.28995362 0.5621509 -2.47347951
		 0.28995362 0.56215078 -2.41765356 0.33161086 0.56215072 -2.41765356 0.33161086 0.56215078 -2.47347951
		 -0.28857157 0.85381258 -2.0035889149 0.28857157 0.85381258 -2.0035889149 -0.28857157 0.91179687 -2.0035889149
		 0.28857157 0.91179687 -2.0035889149 -0.28857157 0.91179687 -2.23510528 0.28857157 0.91179687 -2.23510528
		 -0.28857157 0.85381258 -2.23510528 0.28857157 0.85381258 -2.23510528 -0.37238473 1.21278942 -2.16729903
		 0.37238473 1.21278942 -2.16729903 -0.37238473 1.27077377 -2.16729903 0.37238473 1.27077377 -2.16729903
		 -0.37238473 1.27077377 -2.39881539 0.37238473 1.27077377 -2.39881539 -0.37238473 1.21278942 -2.39881539
		 0.37238473 1.21278942 -2.39881539;
	setAttr -s 154 ".ed[0:153]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0 8 9 0 10 11 1 12 13 0 14 15 0 8 61 0 9 62 0 10 12 0
		 11 13 0 12 17 0 13 18 0 14 8 0 15 9 0 16 10 1 17 64 0 16 17 1 18 67 0 17 18 1 19 11 1
		 18 19 1 19 16 0 19 20 0 16 21 0 20 21 0 20 11 1 21 10 1 20 22 1 21 23 1 22 23 0 11 24 0
		 22 24 0 10 25 0 25 24 0 23 25 0 20 26 0 21 27 0 26 27 0 22 28 0 26 28 0 23 29 0 28 29 0
		 27 29 0 30 31 0 32 33 1 34 35 0 36 37 0 30 53 0 31 54 0 32 34 0 33 35 0 34 39 0 35 40 0
		 36 30 0 37 31 0 38 32 1 39 56 0 38 39 1 40 59 0 39 40 1 41 33 1 40 41 1 41 38 0 41 42 0
		 38 43 0 42 43 0 42 33 1 43 32 1 42 44 1 43 45 1 44 45 0 33 46 0 44 46 0 32 47 0 47 46 0
		 45 47 0 42 48 0 43 49 0 48 49 0 44 50 0 48 50 0 45 51 0 50 51 0 49 51 0 52 36 0 53 57 0
		 52 53 1 54 58 0 53 54 1 55 37 0 54 55 0 55 52 1 56 52 0 57 38 0 56 57 1 58 41 0 57 58 1
		 59 55 0 58 59 0 59 56 1 60 14 0 61 65 0 60 61 0 62 66 0 61 62 1 63 15 0 62 63 1 63 60 1
		 64 60 0 65 16 0 64 65 0 66 19 0 65 66 1 67 63 0 66 67 1 67 64 1 58 65 0 54 61 0 55 60 0
		 59 64 0 68 69 0 70 71 0 72 73 0 74 75 0 68 70 0 69 71 0 70 72 0 71 73 0 72 74 0 73 75 0
		 74 68 0 75 69 0 76 77 0 78 79 0 80 81 0 82 83 0 76 78 0 77 79 0 78 80 0 79 81 0 80 82 0
		 81 83 0 82 76 0 83 77 0;
	setAttr -s 78 -ch 308 ".fc[0:77]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13
		f 4 122 121 31 -120
		mu 0 4 14 15 16 17
		f 4 13 19 -15 -19
		mu 0 4 18 19 20 21
		f 4 28 27 125 -26
		mu 0 4 22 23 24 25
		f 4 15 23 -13 -23
		mu 0 4 26 27 28 29
		f 4 124 -28 30 -122
		mu 0 4 15 30 31 16
		f 4 120 119 26 25
		mu 0 4 32 14 17 33
		f 4 -27 24 18 20
		mu 0 4 33 17 18 34
		f 4 14 21 -29 -21
		mu 0 4 21 20 23 22
		f 4 -31 -22 -20 -30
		mu 0 4 16 31 35 19
		f 4 -40 41 -44 -45
		mu 0 4 36 37 38 39
		f 4 -32 32 34 -34
		mu 0 4 17 16 40 41
		f 3 29 -36 -33
		mu 0 3 16 19 40
		f 3 -25 33 36
		mu 0 3 18 17 41
		f 4 -48 49 51 -53
		mu 0 4 42 43 44 45
		f 4 35 40 -42 -38
		mu 0 4 40 19 38 37
		f 4 -14 42 43 -41
		mu 0 4 19 18 39 38
		f 4 -37 38 44 -43
		mu 0 4 18 41 36 39
		f 4 -35 45 47 -47
		mu 0 4 41 40 43 42
		f 4 37 48 -50 -46
		mu 0 4 40 37 44 43
		f 4 39 50 -52 -49
		mu 0 4 37 36 45 44
		f 4 -39 46 52 -51
		mu 0 4 36 41 42 45
		f 4 106 105 72 -104
		mu 0 4 46 47 48 49
		f 4 54 60 -56 -60
		mu 0 4 50 51 52 53
		f 4 69 68 109 -67
		mu 0 4 54 55 56 57
		f 4 56 64 -54 -64
		mu 0 4 58 59 60 61
		f 4 108 -69 71 -106
		mu 0 4 47 62 63 48
		f 4 104 103 67 66
		mu 0 4 64 46 49 65
		f 4 -68 65 59 61
		mu 0 4 65 49 50 66
		f 4 55 62 -70 -62
		mu 0 4 53 52 55 54
		f 4 -72 -63 -61 -71
		mu 0 4 48 63 67 51
		f 4 -81 82 -85 -86
		mu 0 4 68 69 70 71
		f 4 -73 73 75 -75
		mu 0 4 49 48 72 73
		f 3 70 -77 -74
		mu 0 3 48 51 72
		f 3 -66 74 77
		mu 0 3 50 49 73
		f 4 -89 90 92 -94
		mu 0 4 74 75 76 77
		f 4 76 81 -83 -79
		mu 0 4 72 51 70 69
		f 4 -55 83 84 -82
		mu 0 4 51 50 71 70
		f 4 -78 79 85 -84
		mu 0 4 50 73 68 71
		f 4 -76 86 88 -88
		mu 0 4 73 72 75 74
		f 4 78 89 -91 -87
		mu 0 4 72 69 76 75
		f 4 80 91 -93 -90
		mu 0 4 69 68 77 76
		f 4 -80 87 93 -92
		mu 0 4 68 73 74 77
		f 4 63 57 -97 94
		mu 0 4 78 79 80 81
		f 4 53 58 -99 -58
		mu 0 4 79 82 83 80
		f 4 -65 -100 -101 -59
		mu 0 4 82 84 85 83
		f 4 -102 99 -57 -95
		mu 0 4 86 87 59 58
		f 4 96 95 -105 102
		mu 0 4 81 80 46 64
		f 4 98 97 -107 -96
		mu 0 4 80 83 47 46
		f 4 -110 107 101 -103
		mu 0 4 57 56 87 86
		f 4 22 16 -113 110
		mu 0 4 88 89 90 91
		f 4 12 17 -115 -17
		mu 0 4 89 92 93 90
		f 4 -24 -116 -117 -18
		mu 0 4 92 94 95 93
		f 4 -118 115 -16 -111
		mu 0 4 96 97 27 26
		f 4 114 113 -123 -112
		mu 0 4 90 93 15 14
		f 4 116 -124 -125 -114
		mu 0 4 93 95 30 15
		f 4 -126 123 117 -119
		mu 0 4 25 24 97 96
		f 4 -98 127 111 -127
		mu 0 4 47 83 90 14
		f 4 100 128 112 -128
		mu 0 4 83 85 91 90
		f 4 -108 129 118 -129
		mu 0 4 87 56 25 96
		f 4 -109 126 -121 -130
		mu 0 4 62 47 14 32
		f 4 130 135 -132 -135
		mu 0 4 98 99 100 101
		f 4 131 137 -133 -137
		mu 0 4 101 100 102 103
		f 4 132 139 -134 -139
		mu 0 4 103 102 104 105
		f 4 133 141 -131 -141
		mu 0 4 105 104 106 107
		f 4 -142 -140 -138 -136
		mu 0 4 99 108 109 100
		f 4 140 134 136 138
		mu 0 4 110 98 101 111
		f 4 142 147 -144 -147
		mu 0 4 112 113 114 115
		f 4 143 149 -145 -149
		mu 0 4 115 114 116 117
		f 4 144 151 -146 -151
		mu 0 4 117 116 118 119
		f 4 145 153 -143 -153
		mu 0 4 119 118 120 121
		f 4 -154 -152 -150 -148
		mu 0 4 113 122 123 114
		f 4 152 146 148 150
		mu 0 4 124 112 115 125;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode lightLinker -s -n "lightLinker1";
	rename -uid "59A44308-4C78-DAA1-E4C9-699F9AC42123";
	setAttr -s 20 ".lnk";
	setAttr -s 20 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "95362D4A-4F0D-D12A-0B50-E384814E2F41";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "570EC25A-4636-AE88-5FA3-408BB3A78768";
createNode displayLayerManager -n "layerManager";
	rename -uid "089D318A-45E9-B1F5-8C41-B09FBC56F910";
	setAttr ".cdl" 3;
	setAttr -s 4 ".dli[1:3]"  3 2 1;
	setAttr -s 4 ".dli";
createNode displayLayer -n "defaultLayer";
	rename -uid "8DD8A0B4-4726-ED14-3BBA-6E8D52D63092";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "0219AB72-47D6-FBC8-A88C-538E34C82862";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "FDEAE71E-4A54-BBFF-AF2E-F8AC07D3DF56";
	setAttr ".g" yes;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "932EA826-474D-FBD2-9E70-74A73F099B4C";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n"
		+ "            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n"
		+ "            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n"
		+ "            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 456\n            -height 347\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 1\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n"
		+ "            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 456\n            -height 319\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 1\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n"
		+ "            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n"
		+ "            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 456\n            -height 319\n"
		+ "            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 1\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n"
		+ "            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n"
		+ "            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n"
		+ "            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 456\n            -height 347\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -docTag \"isolOutln_fromSeln\" \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n"
		+ "            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n"
		+ "            -isSet 0\n            -isSetMember 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n            -expandAttribute 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n"
		+ "            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n"
		+ "\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n"
		+ "                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n"
		+ "                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 1\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n"
		+ "                -showCurveNames 0\n                -showActiveCurveNames 0\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                -valueLinesToggle 1\n                -outliner \"graphEditor1OutlineEd\" \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n"
		+ "                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n"
		+ "                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n"
		+ "                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n"
		+ "            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n"
		+ "                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n"
		+ "\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n"
		+ "\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n"
		+ "\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"Stereo\" (localizedPanelLabel(\"Stereo\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Stereo\")) -mbv $menusOkayInPanels  $panelName;\nstring $editorName = ($panelName+\"Editor\");\n            stereoCameraView -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n"
		+ "                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 32768\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 4 4 \n                -bumpResolution 4 4 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 0\n                -occlusionCulling 0\n                -shadingModel 0\n"
		+ "                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -controllers 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n"
		+ "                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 0\n                -height 0\n                -sceneRenderFilter 0\n                -displayMode \"centerEye\" \n                -viewColor 0 0 0 1 \n                -useCustomBackground 1\n                $editorName;\n            stereoCameraView -e -viewSelected 0 $editorName;\n            stereoCameraView -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -highlightConnections 0\n                -copyConnectionsOnPaste 0\n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n"
		+ "                -extendToShapes 1\n                -activeTab -1\n                -editorMode \"default\" \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"vacantCell.xP:/\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"quad\\\" -ps 1 50 52 -ps 2 50 52 -ps 3 50 48 -ps 4 50 48 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Top View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Top View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera top` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"wireframe\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 456\\n    -height 347\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Top View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera top` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"wireframe\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 456\\n    -height 347\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 1\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 456\\n    -height 347\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 1\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 456\\n    -height 347\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Side View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Side View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera side` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"wireframe\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 1\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 456\\n    -height 319\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Side View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera side` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"wireframe\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 1\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 456\\n    -height 319\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Front View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Front View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera front` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"wireframe\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 1\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 456\\n    -height 319\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Front View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera front` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"wireframe\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 1\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 456\\n    -height 319\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "0014A959-4FD2-339F-0937-FDA5AC4E4AE2";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 120 -ast 1 -aet 200 ";
	setAttr ".st" 6;
createNode displayLayer -n "InnerRef";
	rename -uid "049B7730-4CDA-3EF8-F1E8-B89137DCDCD4";
	setAttr ".dt" 2;
	setAttr ".do" 1;
createNode shadingEngine -n "lambert2SG";
	rename -uid "B0453C7C-4DC3-80D9-6F30-CFB8B5F5D309";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo1";
	rename -uid "C6448EF2-4129-2158-3DF2-E5B0BC950418";
createNode displayLayer -n "OutterRef";
	rename -uid "2C13BEB4-4ECF-10A9-189D-CF9456B4ABCC";
	setAttr ".dt" 2;
	setAttr ".v" no;
	setAttr ".do" 2;
createNode groupId -n "groupId29";
	rename -uid "B319AF73-4D2B-B001-D183-FB9A0C9B9728";
	setAttr ".ihi" 0;
createNode displayLayer -n "UVRef";
	rename -uid "2A4B3A4C-4AAC-CF0C-E820-3A8B5203BABF";
	setAttr ".dt" 2;
	setAttr ".do" 3;
createNode groupId -n "groupId51";
	rename -uid "5FEF034E-45CE-8686-4150-E39FDFDAB35D";
	setAttr ".ihi" 0;
createNode groupId -n "groupId53";
	rename -uid "44F053C2-42CE-C680-66D5-41AFA62ED3D0";
	setAttr ".ihi" 0;
createNode polyUnite -n "polyUnite1";
	rename -uid "B97C5C64-4888-2D43-1C72-F09E8C67B4BB";
createNode shadingEngine -n "lambert3SG";
	rename -uid "9DD427C7-484B-30C2-5046-60823548A420";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo2";
	rename -uid "C4DFAE94-4EB2-B2A7-FC79-62A047CBEA9A";
createNode file -n "file1";
	rename -uid "740C492D-4014-0E37-0C7E-C28A282A1CD1";
	setAttr ".ftn" -type "string" "D:/UnityProjects/Crowd/MayaProject//sourceimages/Level1_Inner_uv.png";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "place2dTexture1";
	rename -uid "26645289-44A0-8112-E2FC-EABAD4286F70";
createNode groupId -n "groupId75";
	rename -uid "22A911A8-49E0-F490-1C27-C2A96E2D397E";
	setAttr ".ihi" 0;
createNode shadingEngine -n "lambert4SG";
	rename -uid "B260BE79-48B3-DEE5-5D0A-8A8BE6C6D129";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo3";
	rename -uid "38598ED2-4FF9-D8BF-4439-E0BCFBC50D12";
createNode bulge -n "bulge1";
	rename -uid "A52FAA49-4B34-3932-45D3-3E95356C07C7";
createNode place2dTexture -n "place2dTexture2";
	rename -uid "FFB0A5D1-4E50-8C7A-CC89-8B93028EBAAC";
	setAttr ".re" -type "float2" 4 4 ;
createNode shadingEngine -n "bifrostLiquidMaterial1SG";
	rename -uid "2C993348-4C06-66C7-E824-9595D4CF61BB";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo4";
	rename -uid "68397904-4CCB-43E7-72B1-32A1251BC37D";
createNode shadingEngine -n "blinn1SG";
	rename -uid "2FEBAE97-4FFA-4FA2-344E-30AC8AE31AEE";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo5";
	rename -uid "FAD5C0E9-426A-BD77-266C-30936328B123";
createNode shadingEngine -n "anisotropic1SG";
	rename -uid "2202AFEE-4BDC-63B8-1747-17A554DF1494";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo6";
	rename -uid "B02C5990-4341-25F8-B82F-DDBDC503D55C";
createNode shadingEngine -n "ShaderfxGameHair1SG";
	rename -uid "1B215493-4564-E6E3-D7ED-CF988019E970";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo7";
	rename -uid "22D887B8-4090-342F-F9DE-DB9581101A33";
createNode file -n "file2";
	rename -uid "342DCAAB-45DE-3241-8DAF-65A3E0B4EE12";
	setAttr ".ftn" -type "string" "D:/Autodesk/Maya2018/presets/Assets/Textures/curls_hair_v2.png";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "place2dTexture3";
	rename -uid "9C802DBA-4226-50A6-BDD3-BD9D428D2999";
createNode file -n "file3";
	rename -uid "2AEF4064-488B-4E64-71F5-BF85518D5F0A";
	setAttr ".ftn" -type "string" "D:/Autodesk/Maya2018/presets/Assets/Textures/hair_breakup.png";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "place2dTexture4";
	rename -uid "7B6AA111-4C24-18AA-2864-68B1E9009266";
createNode objectSet -n "Platform2HandleShapeHiddenFacesSet";
	rename -uid "B119FB2A-41D7-CDD4-2051-C3A2586C84AB";
	setAttr ".ihi" 0;
createNode objectSet -n "Platform2HandleShapeHiddenFacesSet1";
	rename -uid "97AF70AA-4246-3EB9-0602-7B8BD82194E8";
	setAttr ".ihi" 0;
createNode shadingEngine -n "lambert5SG";
	rename -uid "2221DA23-422E-5E40-51EC-E8AAA8471982";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo8";
	rename -uid "E655FEA8-42F7-A47D-D37C-2BBFE1F07F3F";
createNode shadingEngine -n "BoatSG";
	rename -uid "28AB7CCD-4CF5-048F-CB63-A391EA3B090B";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo9";
	rename -uid "55D26B78-4679-F6E8-4383-09B4D718419E";
createNode shadingEngine -n "Coach1SG";
	rename -uid "A1FC0E4E-49F5-3AFC-8A08-B6929770C941";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo10";
	rename -uid "04941431-4A7B-5EFE-BB24-7AB9F4CC98FD";
createNode shadingEngine -n "BackShellSG";
	rename -uid "57BA8439-4FD4-75E3-F998-05AAEA452EA2";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo11";
	rename -uid "46F1CE3B-40E3-6FF4-8FD6-C99412F11D0B";
createNode file -n "file4";
	rename -uid "FB137584-4934-0688-B3AB-DD807FEC5FA5";
	setAttr ".ail" yes;
	setAttr ".ftn" -type "string" "D:/UnityProjects/Crowd/Assets/Textures/penguin_uv.png";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "place2dTexture5";
	rename -uid "51F98AFD-4821-99AC-D9A4-42960C2D1B4E";
createNode shadingEngine -n "Platform1SG";
	rename -uid "842D3A12-4C29-2064-4C35-909B19766616";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo12";
	rename -uid "BA4D6EE2-41DA-5C1C-2A61-019C88421C47";
createNode shadingEngine -n "PlatformDecoSG";
	rename -uid "81B77329-4754-B72B-BBCB-D5A15787E6CF";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo13";
	rename -uid "64D3C968-4CB4-83C6-6C83-28A967A7D763";
createNode shadingEngine -n "Left_EarSG";
	rename -uid "F23520B0-4889-19C0-B354-C99ADE3F04CA";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo14";
	rename -uid "0EFC04B7-4375-6CF5-7709-0E9CC70B8803";
createNode file -n "file5";
	rename -uid "62807B57-4611-D2EA-A3F2-DDB877AED2D9";
	setAttr ".ftn" -type "string" "D:/UnityProjects/Crowd/Assets/Textures/penguin_uv.png";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "place2dTexture6";
	rename -uid "791D788A-4860-80F9-B693-02A8E36B88DB";
createNode lambert -n "InnerMat";
	rename -uid "FF579F0E-44EC-7B42-4827-A5B57710902D";
createNode shadingEngine -n "Platform1SG1";
	rename -uid "58DA0334-4D47-2C51-13E6-8CA389B76C22";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo15";
	rename -uid "93E39EBA-491C-7747-6E7B-7FB1D67A8135";
createNode lambert -n "CutoutMat";
	rename -uid "430E2F02-4E70-0B61-73AC-468A48F1F7C2";
	setAttr ".c" -type "float3" 0.62819999 0.87199998 0.61549997 ;
	setAttr ".it" -type "float3" 0.48701298 0.48701298 0.48701298 ;
createNode shadingEngine -n "PlatformDecoSG1";
	rename -uid "D86FCD87-4093-089C-D1E6-4F8C769914A9";
	setAttr ".ihi" 0;
	setAttr -s 20 ".dsm";
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo16";
	rename -uid "07626309-4639-6DD4-8750-74B104631234";
createNode lambert -n "OutterMat";
	rename -uid "10098A77-469F-9E9E-9215-1AAC1611FE8F";
createNode shadingEngine -n "Left_EarSG1";
	rename -uid "51076508-4AD1-B2B9-7EC9-DBAE62CBB80F";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo17";
	rename -uid "8DD0B643-4D43-4461-0F62-E3977CA1154D";
createNode file -n "file6";
	rename -uid "8F53A32D-4FBB-5120-6CA3-2CA0D23172E4";
	setAttr ".ftn" -type "string" "D:/UnityProjects/Crowd/Assets/Textures/penguin_uv.png";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "place2dTexture7";
	rename -uid "FF9BE076-4F0D-32FC-7F74-4281373BF59C";
createNode objectSet -n "textureEditorIsolateSelectSet";
	rename -uid "E8F08D0A-423A-49B8-E260-B3BE4B79200D";
	setAttr ".ihi" 0;
	setAttr ".fo" yes;
createNode lambert -n "Water";
	rename -uid "06C60956-4142-BC46-DE7E-94A70DF55959";
	setAttr ".c" -type "float3" 0.0244 0.0964 0.3123 ;
createNode shadingEngine -n "lambert6SG";
	rename -uid "C6CCB497-427A-BB5B-799B-AB934B75FE27";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo18";
	rename -uid "73DD4D2B-4DE7-1531-AF2B-0F81AFEE725E";
createNode groupId -n "groupId77";
	rename -uid "B2202B54-4F9C-FECF-1D1D-229BD4E0B716";
	setAttr ".ihi" 0;
createNode groupId -n "groupId79";
	rename -uid "DE03C4BC-4080-2DA8-E5E8-9F9D5357FCE4";
	setAttr ".ihi" 0;
createNode polyCube -n "polyCube1";
	rename -uid "FFC08450-467A-8594-8298-81BFDF618BCE";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".w" 1;
	setAttr ".h" 1;
	setAttr ".d" 1;
	setAttr ".cuv" 4;
createNode transformGeometry -n "transformGeometry1";
	rename -uid "D193D033-4B57-DAC4-D38F-5DB7375A51C3";
	setAttr ".txf" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 50 0 1;
createNode nodeGraphEditorInfo -n "hyperShadePrimaryNodeEditorSavedTabsInfo";
	rename -uid "47944F53-4436-3EC0-5CD7-90AB3B7E3E35";
	setAttr ".tgi[0].tn" -type "string" "Untitled_1";
	setAttr ".tgi[0].vl" -type "double2" -765.47616005890086 -991.68410214054131 ;
	setAttr ".tgi[0].vh" -type "double2" 202.38094433905613 77.398424185275388 ;
	setAttr -s 19 ".tgi[0].ni";
	setAttr ".tgi[0].ni[0].x" 78.571426391601563;
	setAttr ".tgi[0].ni[0].y" 45.714286804199219;
	setAttr ".tgi[0].ni[0].nvs" 1923;
	setAttr ".tgi[0].ni[1].x" -551.4285888671875;
	setAttr ".tgi[0].ni[1].y" -320;
	setAttr ".tgi[0].ni[1].nvs" 1923;
	setAttr ".tgi[0].ni[2].x" -235.71427917480469;
	setAttr ".tgi[0].ni[2].y" -104.28571319580078;
	setAttr ".tgi[0].ni[2].nvs" 1923;
	setAttr ".tgi[0].ni[3].x" -228.57142639160156;
	setAttr ".tgi[0].ni[3].y" 67.142860412597656;
	setAttr ".tgi[0].ni[3].nvs" 1923;
	setAttr ".tgi[0].ni[4].x" -228.57142639160156;
	setAttr ".tgi[0].ni[4].y" -272.85714721679688;
	setAttr ".tgi[0].ni[4].nvs" 1923;
	setAttr ".tgi[0].ni[5].x" -858.5714111328125;
	setAttr ".tgi[0].ni[5].y" -341.42855834960938;
	setAttr ".tgi[0].ni[5].nvs" 1923;
	setAttr ".tgi[0].ni[6].x" -747.14288330078125;
	setAttr ".tgi[0].ni[6].y" -582.85711669921875;
	setAttr ".tgi[0].ni[6].nvs" 1923;
	setAttr ".tgi[0].ni[7].x" -858.5714111328125;
	setAttr ".tgi[0].ni[7].y" -165.71427917480469;
	setAttr ".tgi[0].ni[7].nvs" 1923;
	setAttr ".tgi[0].ni[8].x" -551.4285888671875;
	setAttr ".tgi[0].ni[8].y" -144.28572082519531;
	setAttr ".tgi[0].ni[8].nvs" 1923;
	setAttr ".tgi[0].ni[9].x" 81.428573608398438;
	setAttr ".tgi[0].ni[9].y" -115.71428680419922;
	setAttr ".tgi[0].ni[9].nvs" 1923;
	setAttr ".tgi[0].ni[10].x" -842.85711669921875;
	setAttr ".tgi[0].ni[10].y" -58.571430206298828;
	setAttr ".tgi[0].ni[10].nvs" 1923;
	setAttr ".tgi[0].ni[11].x" 78.571426391601563;
	setAttr ".tgi[0].ni[11].y" -272.85714721679688;
	setAttr ".tgi[0].ni[11].nvs" 1923;
	setAttr ".tgi[0].ni[12].x" -228.57142639160156;
	setAttr ".tgi[0].ni[12].y" -612.85711669921875;
	setAttr ".tgi[0].ni[12].nvs" 1923;
	setAttr ".tgi[0].ni[13].x" 78.571426391601563;
	setAttr ".tgi[0].ni[13].y" -612.85711669921875;
	setAttr ".tgi[0].ni[13].nvs" 1923;
	setAttr ".tgi[0].ni[14].x" -440;
	setAttr ".tgi[0].ni[14].y" -582.85711669921875;
	setAttr ".tgi[0].ni[14].nvs" 1923;
	setAttr ".tgi[0].ni[15].x" -535.71429443359375;
	setAttr ".tgi[0].ni[15].y" -35.714286804199219;
	setAttr ".tgi[0].ni[15].nvs" 1923;
	setAttr ".tgi[0].ni[16].x" -235.71427917480469;
	setAttr ".tgi[0].ni[16].y" -70;
	setAttr ".tgi[0].ni[16].nvs" 1923;
	setAttr ".tgi[0].ni[17].x" -230;
	setAttr ".tgi[0].ni[17].y" -537.14288330078125;
	setAttr ".tgi[0].ni[17].nvs" 1923;
	setAttr ".tgi[0].ni[18].x" -235.71427917480469;
	setAttr ".tgi[0].ni[18].y" -194.28572082519531;
	setAttr ".tgi[0].ni[18].nvs" 1923;
createNode polyCube -n "polyCube2";
	rename -uid "C7DBA4FA-4F5F-6F4E-5E57-E68008D43E7C";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".w" 1;
	setAttr ".h" 1;
	setAttr ".d" 1;
	setAttr ".cuv" 4;
createNode polyCube -n "polyCube3";
	rename -uid "69E7F6A5-4C67-6F7E-A3CF-E39D281E99B6";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".w" 1;
	setAttr ".h" 1;
	setAttr ".d" 1;
	setAttr ".sw" 10;
	setAttr ".sd" 10;
	setAttr ".cuv" 4;
createNode polyTweak -n "polyTweak1";
	rename -uid "C9D8331C-4F51-37D3-3B93-3BBB3CF21718";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[71]" -type "float3" 0 -0.00051879883 0 ;
	setAttr ".tk[192]" -type "float3" 0 3.0517578e-05 0 ;
createNode polySplit -n "polySplit1";
	rename -uid "30466B7B-45C2-A7E0-FBBD-0C81D9B9FAD9";
	setAttr -s 3 ".e[0:2]"  1 0 0;
	setAttr -s 3 ".d[0:2]"  -2147483355 -2147483582 -2147483593;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit2";
	rename -uid "52F2E080-4DE2-E96B-ACD8-AF9D2ABB070C";
	setAttr -s 3 ".e[0:2]"  1 0 0;
	setAttr -s 3 ".d[0:2]"  -2147483482 -2147483472 -2147483463;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit3";
	rename -uid "D7EF89B4-4AB8-747D-BF5B-05BCEC967A1D";
	setAttr -s 3 ".e[0:2]"  1 0 0;
	setAttr -s 3 ".d[0:2]"  -2147483592 -2147483582 -2147483573;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit4";
	rename -uid "B591C60F-41A9-3BB8-7F6E-CEB877204E04";
	setAttr -s 3 ".e[0:2]"  1 0 0;
	setAttr -s 3 ".d[0:2]"  -2147483234 -2147483235 -2147483483;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweak -n "polyTweak2";
	rename -uid "AC98B11E-40EB-3112-FD9D-39908FBC7A61";
	setAttr ".uopa" yes;
	setAttr -s 17 ".tk";
	setAttr ".tk[60]" -type "float3" 0 0 1.758386 ;
	setAttr ".tk[61]" -type "float3" 0 0 -0.27476186 ;
	setAttr ".tk[62]" -type "float3" 0 0 1.758386 ;
	setAttr ".tk[71]" -type "float3" 1.297067 0 0 ;
	setAttr ".tk[72]" -type "float3" 0 618.95825 0 ;
	setAttr ".tk[73]" -type "float3" -1.2970672 0 0 ;
	setAttr ".tk[82]" -type "float3" 0 0 -1.8873503 ;
	setAttr ".tk[83]" -type "float3" 0 0 0.14579672 ;
	setAttr ".tk[84]" -type "float3" 0 0 -1.8873503 ;
	setAttr ".tk[181]" -type "float3" 0 0 -1.8873503 ;
	setAttr ".tk[182]" -type "float3" 0 0 0.14579672 ;
	setAttr ".tk[183]" -type "float3" 0 0 -1.8873503 ;
	setAttr ".tk[192]" -type "float3" 1.297067 0 0 ;
	setAttr ".tk[194]" -type "float3" -1.2970672 0 0 ;
	setAttr ".tk[203]" -type "float3" 0 0 1.758386 ;
	setAttr ".tk[204]" -type "float3" 0 0 -0.27476186 ;
	setAttr ".tk[205]" -type "float3" 0 0 1.758386 ;
createNode polySplit -n "polySplit5";
	rename -uid "0477774F-47D7-7E77-52F0-DC9C3F0AF65A";
	setAttr -s 3 ".e[0:2]"  0 1 0;
	setAttr -s 3 ".d[0:2]"  -2147483589 -2147483363 -2147483569;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit6";
	rename -uid "3F063FE6-45F7-38FC-E3F7-10A8C0707A49";
	setAttr -s 3 ".e[0:2]"  0 1 0;
	setAttr -s 3 ".d[0:2]"  -2147483459 -2147483469 -2147483479;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit7";
	rename -uid "30D5927C-4E4E-A70B-B084-ACA2A5177A34";
	setAttr -s 3 ".e[0:2]"  1 0 1;
	setAttr -s 3 ".d[0:2]"  -2147483596 -2147483586 -2147483359;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit8";
	rename -uid "FB6B4813-4D32-3A26-AD4E-C38B56BEE7FE";
	setAttr -s 3 ".e[0:2]"  1 0 1;
	setAttr -s 3 ".d[0:2]"  -2147483238 -2147483476 -2147483486;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode deleteComponent -n "deleteComponent1";
	rename -uid "03A06D64-4AC4-0783-8CE2-0D81DE2512B6";
	setAttr ".dc" -type "componentList" 5 "f[50:51]" "f[60:61]" "f[160:161]" "f[170:171]" "f[234:235]";
createNode deleteComponent -n "deleteComponent2";
	rename -uid "1F10A3D0-4C44-C26B-9422-E29B4834D98C";
	setAttr ".dc" -type "componentList" 3 "f[50]" "f[58]" "f[244:245]";
createNode deleteComponent -n "deleteComponent3";
	rename -uid "4113A4D0-46C8-835F-D3A7-41B6BA90703B";
	setAttr ".dc" -type "componentList" 3 "f[161]" "f[169]" "f[236:237]";
createNode deleteComponent -n "deleteComponent4";
	rename -uid "829EC4F6-436D-2194-3C54-278F8D05302B";
	setAttr ".dc" -type "componentList" 1 "f[212:213]";
createNode deleteComponent -n "deleteComponent5";
	rename -uid "7C6C3870-4FA1-1AA8-AA04-1CB22FFB0FC9";
	setAttr ".dc" -type "componentList" 4 "f[47:49]" "f[71:73]" "f[151:153]" "f[175:177]";
createNode deleteComponent -n "deleteComponent6";
	rename -uid "F67532A0-441D-2206-C6E3-D6ACCBC4C4A2";
	setAttr ".dc" -type "componentList" 1 "f[199:200]";
createNode deleteComponent -n "deleteComponent7";
	rename -uid "30B2F6CF-4258-C9C7-11EA-7BB1196E7B77";
	setAttr ".dc" -type "componentList" 2 "f[61:65]" "f[138:142]";
createNode deleteComponent -n "deleteComponent8";
	rename -uid "ECABD1F4-4D98-8302-1E70-23A72A959F91";
	setAttr ".dc" -type "componentList" 1 "f[195]";
createNode deleteComponent -n "deleteComponent9";
	rename -uid "3B01BC5E-4727-175B-E660-2CB2D8CC8460";
	setAttr ".dc" -type "componentList" 2 "f[40:44]" "f[149:153]";
createNode deleteComponent -n "deleteComponent10";
	rename -uid "539EDEF8-492E-26C4-4A49-BCACF3C79635";
	setAttr ".dc" -type "componentList" 1 "f[185]";
createNode polyDelEdge -n "polyDelEdge1";
	rename -uid "15A11742-4858-58BB-CEB3-63AAB4399458";
	setAttr ".ics" -type "componentList" 2 "e[247]" "e[254]";
	setAttr ".cv" yes;
createNode polyTweak -n "polyTweak3";
	rename -uid "0823CB90-4A18-6C63-3241-D5BBBA18D274";
	setAttr ".uopa" yes;
	setAttr -s 118 ".tk";
	setAttr ".tk[0]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[1]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[2]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[3]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[4]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[5]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[6]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[7]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[8]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[9]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[10]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[56]" -type "float3" 5.3748021 3027.4141 1.4581634 ;
	setAttr ".tk[60]" -type "float3" -5.3747997 3027.4141 1.4581634 ;
	setAttr ".tk[64]" -type "float3" 7.2258329 2233.8623 0 ;
	setAttr ".tk[66]" -type "float3" 0 3125.6831 0 ;
	setAttr ".tk[68]" -type "float3" -7.2258339 2233.8623 0 ;
	setAttr ".tk[72]" -type "float3" 5.3748021 3027.4141 -1.4581634 ;
	setAttr ".tk[76]" -type "float3" -5.3747997 3027.4141 -1.4581634 ;
	setAttr ".tk[122]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[123]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[124]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[125]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[126]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[127]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[128]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[129]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[130]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[131]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[132]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[133]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[134]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[135]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[136]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[137]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[138]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[139]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[140]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[141]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[142]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[143]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[144]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[145]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[146]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[147]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[148]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[149]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[150]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[151]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[152]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[153]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[154]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[155]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[156]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[157]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[158]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[159]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[160]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[161]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[162]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[163]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[164]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[165]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[166]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[167]" -type "float3" 5.3748021 3027.4141 -1.4581634 ;
	setAttr ".tk[168]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[169]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[170]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[171]" -type "float3" -5.3747997 3027.4141 -1.4581634 ;
	setAttr ".tk[172]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[173]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[174]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[175]" -type "float3" 7.2258329 2233.8621 0 ;
	setAttr ".tk[176]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[177]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[178]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[179]" -type "float3" -7.2258339 2233.8621 0 ;
	setAttr ".tk[180]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[181]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[182]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[183]" -type "float3" 5.3748021 3027.4141 1.4581634 ;
	setAttr ".tk[184]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[185]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[186]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[187]" -type "float3" -5.3747997 3027.4141 1.4581634 ;
	setAttr ".tk[188]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[189]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[190]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[191]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[192]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[193]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[194]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[195]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[196]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[197]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[198]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[199]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[200]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[201]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[202]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[203]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[204]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[205]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[206]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[207]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[208]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[209]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[210]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[211]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[212]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[213]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[214]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[215]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[216]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[217]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[218]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[219]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[220]" -type "float3" 0 7.6293945e-06 0 ;
	setAttr ".tk[221]" -type "float3" 0 7.6293945e-06 0 ;
createNode polyDelEdge -n "polyDelEdge2";
	rename -uid "40CDE367-40ED-6011-394C-DCB5069F19C0";
	setAttr ".ics" -type "componentList" 2 "e[340]" "e[347]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge3";
	rename -uid "889A63EC-4490-DF92-AF64-5694B1623178";
	setAttr ".ics" -type "componentList" 2 "e[248]" "e[254]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge4";
	rename -uid "FAB6FAD5-4C76-1937-B58E-AC8490D7C58F";
	setAttr ".ics" -type "componentList" 2 "e[339]" "e[345]";
	setAttr ".cv" yes;
createNode polyTweak -n "polyTweak4";
	rename -uid "88F95057-4CF1-4B61-A39A-2FA52F4CFD76";
	setAttr ".uopa" yes;
	setAttr -s 16 ".tk";
	setAttr ".tk[56]" -type "float3" 0.94055152 0 -1.1120017 ;
	setAttr ".tk[57]" -type "float3" -3.2750059e-08 0 -1.0325344 ;
	setAttr ".tk[58]" -type "float3" -0.94055152 0 -1.1120017 ;
	setAttr ".tk[62]" -type "float3" 0.91790956 0 -0.0068010725 ;
	setAttr ".tk[64]" -type "float3" -0.9179095 0 -0.0068010725 ;
	setAttr ".tk[68]" -type "float3" 0.94055152 0 1.1120017 ;
	setAttr ".tk[69]" -type "float3" -3.2750059e-08 0 1.0325344 ;
	setAttr ".tk[70]" -type "float3" -0.94055152 0 1.1120017 ;
	setAttr ".tk[161]" -type "float3" 0.94055152 0 1.1120017 ;
	setAttr ".tk[162]" -type "float3" -3.2750059e-08 0 1.0325344 ;
	setAttr ".tk[163]" -type "float3" -0.94055152 0 1.1120017 ;
	setAttr ".tk[167]" -type "float3" 0.91790956 0 -0.0068010725 ;
	setAttr ".tk[169]" -type "float3" -0.9179095 0 -0.0068010725 ;
	setAttr ".tk[173]" -type "float3" 0.94055152 0 -1.1120017 ;
	setAttr ".tk[174]" -type "float3" -3.2750059e-08 0 -1.0325344 ;
	setAttr ".tk[175]" -type "float3" -0.94055152 0 -1.1120017 ;
createNode deleteComponent -n "deleteComponent11";
	rename -uid "CCCC6240-404B-DF15-00BC-56A80E4872C1";
	setAttr ".dc" -type "componentList" 8 "f[61:63]" "f[71:73]" "f[81:83]" "f[91:93]" "f[101:103]" "f[111:113]" "f[121:123]" "f[170:172]";
createNode deleteComponent -n "deleteComponent12";
	rename -uid "3D626028-416F-1E48-DB74-E29351805B56";
	setAttr ".dc" -type "componentList" 8 "f[54:58]" "f[61:65]" "f[68:72]" "f[75:79]" "f[82:86]" "f[89:93]" "f[96:100]" "f[152:154]";
createNode deleteComponent -n "deleteComponent13";
	rename -uid "72928967-4303-1183-ED6D-DD82AC71A883";
	setAttr ".dc" -type "componentList" 7 "f[7:9]" "f[17:19]" "f[27:29]" "f[37:39]" "f[91:93]" "f[101:103]" "f[111:116]";
createNode deleteComponent -n "deleteComponent14";
	rename -uid "CDE8C111-4D3D-E424-081F-73B63AAFEED3";
	setAttr ".dc" -type "componentList" 8 "f[0:4]" "f[7:11]" "f[14:18]" "f[21:25]" "f[72:76]" "f[79:83]" "f[86:90]" "f[93:95]";
createNode polyBridgeEdge -n "polyBridgeEdge1";
	rename -uid "E3334360-4B5F-72C2-6822-FFB10F56234D";
	setAttr ".ics" -type "componentList" 21 "e[10:11]" "e[21]" "e[42:43]" "e[53]" "e[67]" "e[70]" "e[73]" "e[76]" "e[89]" "e[92]" "e[95]" "e[98]" "e[104]" "e[107]" "e[110]" "e[113]" "e[126]" "e[129]" "e[132]" "e[135]" "e[148:149]";
	setAttr ".ix" -type "matrix" 7.5463225370164828 0 0 0 0 0.023443167178317518 0 0
		 0 0 7.5463225370164828 0 -75.463226318359119 0 0 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 3;
	setAttr ".sv2" 44;
	setAttr ".d" 1;
	setAttr ".sd" 1;
createNode polyTweak -n "polyTweak5";
	rename -uid "124CFAED-444D-FA7E-6787-84A4BAFBBB83";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk";
	setAttr ".tk[16]" -type "float3" -0.80186373 0 0 ;
	setAttr ".tk[18]" -type "float3" 0.80186361 0 0 ;
	setAttr ".tk[21]" -type "float3" 1.9796528 327.26416 0 ;
	setAttr ".tk[25]" -type "float3" -1.9796524 327.26416 0 ;
	setAttr ".tk[28]" -type "float3" -0.80186373 0 0 ;
	setAttr ".tk[30]" -type "float3" 0.80186361 0 0 ;
	setAttr ".tk[57]" -type "float3" -0.80186373 0 0 ;
	setAttr ".tk[59]" -type "float3" 0.80186361 0 0 ;
	setAttr ".tk[62]" -type "float3" 1.9796528 327.26416 0 ;
	setAttr ".tk[66]" -type "float3" -1.9796524 327.26416 0 ;
	setAttr ".tk[69]" -type "float3" -0.80186373 0 0 ;
	setAttr ".tk[71]" -type "float3" 0.80186361 0 0 ;
createNode polyBridgeEdge -n "polyBridgeEdge2";
	rename -uid "57DC0E3D-49F7-3D2B-CEDA-76A9EF9F5A49";
	setAttr ".ics" -type "componentList" 21 "e[14]" "e[24:25]" "e[46]" "e[56:57]" "e[69]" "e[72]" "e[75]" "e[78]" "e[91]" "e[94]" "e[97]" "e[100]" "e[106]" "e[109]" "e[112]" "e[115]" "e[128]" "e[131]" "e[134]" "e[137]" "e[146:147]";
	setAttr ".ix" -type "matrix" 7.5463225370164828 0 0 0 0 0.023443167178317518 0 0
		 0 0 7.5463225370164828 0 -75.463226318359119 0 0 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 43;
	setAttr ".sv2" 2;
	setAttr ".d" 1;
	setAttr ".sd" 1;
createNode polyMergeVert -n "polyMergeVert1";
	rename -uid "8ED0BFF9-4561-1DB9-0AEF-15A88BFAAE2B";
	setAttr ".ics" -type "componentList" 1 "vtx[0:81]";
	setAttr ".ix" -type "matrix" 7.5463225370164828 0 0 0 0 0.023443167178317518 0 0
		 0 0 7.5463225370164828 0 -75.463226318359119 0 0 1;
	setAttr ".d" 0.001;
	setAttr ".am" yes;
createNode polySplitRing -n "polySplitRing1";
	rename -uid "2F5BAFCD-4FAE-08E0-7C59-689AF2FDB13A";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[42]" "e[148]";
	setAttr ".ix" -type "matrix" 7.5463225370164828 0 0 0 0 0.023443167178317518 0 0
		 0 0 7.5463225370164828 0 -75.463226318359119 0 0 1;
	setAttr ".wt" 0.52068334817886353;
	setAttr ".dr" no;
	setAttr ".re" 42;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing2";
	rename -uid "CE6823F2-4CD0-325D-82BB-039158CE15C3";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[25]" "e[147]";
	setAttr ".ix" -type "matrix" 7.5463225370164828 0 0 0 0 0.023443167178317518 0 0
		 0 0 7.5463225370164828 0 -75.463226318359119 0 0 1;
	setAttr ".wt" 0.52068334817886353;
	setAttr ".dr" no;
	setAttr ".re" 147;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing3";
	rename -uid "B908FCC7-4DBF-1FA2-7F86-29BBC0011993";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[10]" "e[149]";
	setAttr ".ix" -type "matrix" 7.5463225370164828 0 0 0 0 0.023443167178317518 0 0
		 0 0 7.5463225370164828 0 -75.463226318359119 0 0 1;
	setAttr ".wt" 0.537087082862854;
	setAttr ".dr" no;
	setAttr ".re" 149;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing4";
	rename -uid "27F155B4-4433-E0CA-B035-2A8644696901";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[57]" "e[146]";
	setAttr ".ix" -type "matrix" 7.5463225370164828 0 0 0 0 0.023443167178317518 0 0
		 0 0 7.5463225370164828 0 -75.463226318359119 0 0 1;
	setAttr ".wt" 0.537087082862854;
	setAttr ".dr" no;
	setAttr ".re" 57;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplit -n "polySplit9";
	rename -uid "9482BB8E-4A9A-0DDB-AB67-65A9C44B83D8";
	setAttr -s 3 ".e[0:2]"  1 0.43403101 0;
	setAttr -s 3 ".d[0:2]"  -2147483638 -2147483633 -2147483476;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit10";
	rename -uid "5D89A22A-4699-AB4C-99AE-A598B42FE4EC";
	setAttr -s 3 ".e[0:2]"  1 0.56596899 0;
	setAttr -s 3 ".d[0:2]"  -2147483502 -2147483628 -2147483472;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit11";
	rename -uid "E4D20DC7-4E56-6194-0FF0-089FFFBDD1DA";
	setAttr -s 3 ".e[0:2]"  1 0.43861899 1;
	setAttr -s 3 ".d[0:2]"  -2147483606 -2147483601 -2147483499;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit12";
	rename -uid "0FD80A14-49C4-C376-59AE-9FBA07F7C834";
	setAttr -s 3 ".e[0:2]"  0 0.56138098 0;
	setAttr -s 3 ".d[0:2]"  -2147483473 -2147483596 -2147483467;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweak -n "polyTweak6";
	rename -uid "7FB337CD-4212-ED3A-F9C6-33892CC38E28";
	setAttr ".uopa" yes;
	setAttr -s 20 ".tk";
	setAttr ".tk[15]" -type "float3" -0.53209513 -942.8324 0 ;
	setAttr ".tk[19]" -type "float3" 0.53209513 -942.8324 0 ;
	setAttr ".tk[27]" -type "float3" -0.53209513 -942.8324 0 ;
	setAttr ".tk[31]" -type "float3" 0.53209513 -942.8324 0 ;
	setAttr ".tk[56]" -type "float3" -0.53209513 -942.8324 0 ;
	setAttr ".tk[60]" -type "float3" 0.53209513 -942.8324 0 ;
	setAttr ".tk[68]" -type "float3" -0.53209513 -942.8324 0 ;
	setAttr ".tk[72]" -type "float3" 0.53209513 -942.8324 0 ;
	setAttr ".tk[82]" -type "float3" 5.4730015 1443.3668 -6.1456189 ;
	setAttr ".tk[83]" -type "float3" 5.4730949 1443.3781 -6.1456776 ;
	setAttr ".tk[84]" -type "float3" -5.473093 1443.3778 -6.1456757 ;
	setAttr ".tk[85]" -type "float3" -5.4729977 1443.3668 -6.1456189 ;
	setAttr ".tk[86]" -type "float3" 5.4730015 1443.3668 6.145577 ;
	setAttr ".tk[87]" -type "float3" 5.4733868 1443.413 6.1458073 ;
	setAttr ".tk[88]" -type "float3" -5.473381 1443.4127 6.1458054 ;
	setAttr ".tk[89]" -type "float3" -5.4729977 1443.3668 6.145577 ;
	setAttr ".tk[90]" -type "float3" 7.6739712 826.16907 -4.8288468e-17 ;
	setAttr ".tk[91]" -type "float3" -7.673975 826.16907 -4.8288468e-17 ;
	setAttr ".tk[92]" -type "float3" 7.596632 819.38672 -4.8288468e-17 ;
	setAttr ".tk[93]" -type "float3" -7.5966339 819.3866 -4.8288468e-17 ;
createNode polySplit -n "polySplit13";
	rename -uid "460508F6-412B-73F2-C868-43BA101B4425";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483569 -2147483470;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit14";
	rename -uid "94FDE881-4140-4675-E9A2-C0B1ADAC1345";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483628 -2147483502;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit15";
	rename -uid "6599EE8E-453B-7611-9521-7A8452C8799B";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483464 -2147483476;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit16";
	rename -uid "5D33A395-467B-6DCE-2C41-EF887551052F";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483560 -2147483623;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit17";
	rename -uid "2D299100-4BFB-82B6-4FAD-058968104E58";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483475 -2147483532;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit18";
	rename -uid "CBAC7102-4112-8DB9-3B1A-7EB292F1D30C";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483473 -2147483596;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit19";
	rename -uid "00C0BD71-4A0B-775F-C8EE-DFA675211FC5";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483458 -2147483499;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit20";
	rename -uid "F91C5C2A-4ADE-7948-1AE2-DC99F963CF16";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483523 -2147483591;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweak -n "polyTweak7";
	rename -uid "C2E652CF-41AB-396A-6593-92A21FFA64E9";
	setAttr ".uopa" yes;
	setAttr -s 20 ".tk";
	setAttr ".tk[15]" -type "float3" 0 867.41119 0 ;
	setAttr ".tk[19]" -type "float3" 0 867.41119 0 ;
	setAttr ".tk[20]" -type "float3" -7.4479289 1151.4667 0 ;
	setAttr ".tk[26]" -type "float3" 7.4479289 1151.4667 0 ;
	setAttr ".tk[27]" -type "float3" 0 867.41119 0 ;
	setAttr ".tk[29]" -type "float3" 0 0 3.4559073 ;
	setAttr ".tk[31]" -type "float3" 0 867.41119 0 ;
	setAttr ".tk[32]" -type "float3" 4.272439 3881.572 1.6887631 ;
	setAttr ".tk[33]" -type "float3" 0 4854.3989 4.6546345 ;
	setAttr ".tk[34]" -type "float3" -4.272439 3881.572 1.6887631 ;
	setAttr ".tk[53]" -type "float3" 4.272439 3881.572 1.6887631 ;
	setAttr ".tk[54]" -type "float3" 0 4854.3989 4.6546345 ;
	setAttr ".tk[55]" -type "float3" -4.272439 3881.572 1.6887631 ;
	setAttr ".tk[56]" -type "float3" 0 867.41119 0 ;
	setAttr ".tk[58]" -type "float3" 0 0 3.4559073 ;
	setAttr ".tk[60]" -type "float3" 0 867.41119 0 ;
	setAttr ".tk[61]" -type "float3" -7.4479289 1151.4667 0 ;
	setAttr ".tk[67]" -type "float3" 7.4479289 1151.4667 0 ;
	setAttr ".tk[68]" -type "float3" 0 867.41119 0 ;
	setAttr ".tk[72]" -type "float3" 0 867.41119 0 ;
createNode deleteComponent -n "deleteComponent15";
	rename -uid "06142E73-4538-85A0-612F-7BB0D9ABA687";
	setAttr ".dc" -type "componentList" 2 "f[24:33]" "f[78:81]";
createNode polyTweakUV -n "polyTweakUV1";
	rename -uid "71CBFD97-4780-3456-1626-D78C955A11AC";
	setAttr ".uopa" yes;
	setAttr -s 3 ".uvtk[35:37]" -type "float2" 0.028248822 -0.01345337 0.0012172146
		 -0.0039969813 -0.028248822 -0.013429358;
createNode polyMergeVert -n "polyMergeVert2";
	rename -uid "AE4B148B-4439-4E91-B5FF-03892260EF71";
	setAttr ".ics" -type "componentList" 1 "vtx[35:37]";
	setAttr ".ix" -type "matrix" 7.5463225370164828 0 0 0 0 0.023443167178317518 0 0
		 0 0 7.5463225370164828 0 -75.463226318359119 0 0 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak8";
	rename -uid "8ACE49B3-4E0B-A6A8-BF09-0487FBAA946B";
	setAttr ".uopa" yes;
	setAttr -s 3 ".tk[35:37]" -type "float3"  10 0 0 0 0 0 -10 0 0;
createNode polyTweakUV -n "polyTweakUV2";
	rename -uid "D8D43016-49AD-3D3E-4A5A-4481A56EA385";
	setAttr ".uopa" yes;
	setAttr -s 4 ".uvtk";
	setAttr ".uvtk[36]" -type "float2" 0.028264442 -0.00066000276 ;
	setAttr ".uvtk[37]" -type "float2" -0.0012126226 -0.00014632853 ;
	setAttr ".uvtk[38]" -type "float2" -0.02801382 -0.00064424542 ;
createNode polyMergeVert -n "polyMergeVert3";
	rename -uid "380A65F8-43F1-43E3-8A6C-1F805AA09F7A";
	setAttr ".ics" -type "componentList" 1 "vtx[36:38]";
	setAttr ".ix" -type "matrix" 7.5463225370164828 0 0 0 0 0.023443167178317518 0 0
		 0 0 7.5463225370164828 0 -75.463226318359119 0 0 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak9";
	rename -uid "5A32FB11-43C9-2222-D42C-3FBC6E8D384A";
	setAttr ".uopa" yes;
	setAttr -s 3 ".tk[36:38]" -type "float3"  10 0 0 0 0 0 -10 0 0;
createNode polyDelEdge -n "polyDelEdge5";
	rename -uid "0C0F3CF3-4C65-6AAE-166C-819FF57068B1";
	setAttr ".ics" -type "componentList" 4 "e[4:9]" "e[46:51]" "e[123:125]" "e[139:141]";
	setAttr ".cv" yes;
createNode polyTweak -n "polyTweak10";
	rename -uid "F5B170EF-42E2-8ABD-F3D6-EEAEEC22CCC8";
	setAttr ".uopa" yes;
	setAttr -s 18 ".tk";
	setAttr ".tk[16]" -type "float3" 2.2317827 0 0 ;
	setAttr ".tk[18]" -type "float3" -2.2317827 0 0 ;
	setAttr ".tk[28]" -type "float3" 2.2317829 0 -2.3841858e-07 ;
	setAttr ".tk[29]" -type "float3" 0 0 1.1361285 ;
	setAttr ".tk[30]" -type "float3" -2.2317829 0 -2.3841858e-07 ;
	setAttr ".tk[32]" -type "float3" 3.5103214 4315.7466 0.66148245 ;
	setAttr ".tk[33]" -type "float3" 0 2670.0608 1.8066941 ;
	setAttr ".tk[34]" -type "float3" -3.5103214 4315.7466 0.66148245 ;
	setAttr ".tk[35]" -type "float3" 0 6293.2305 7.0259099 ;
	setAttr ".tk[36]" -type "float3" 0 6293.2305 7.0259099 ;
	setAttr ".tk[37]" -type "float3" 3.5103214 4315.7466 0.66148245 ;
	setAttr ".tk[38]" -type "float3" 0 2670.0608 1.8066941 ;
	setAttr ".tk[39]" -type "float3" -3.5103214 4315.7466 0.66148245 ;
	setAttr ".tk[41]" -type "float3" 2.2317829 0 -2.3841858e-07 ;
	setAttr ".tk[42]" -type "float3" 0 0 1.1361285 ;
	setAttr ".tk[43]" -type "float3" -2.2317829 0 -2.3841858e-07 ;
	setAttr ".tk[53]" -type "float3" 2.2317827 0 0 ;
	setAttr ".tk[55]" -type "float3" -2.2317827 0 0 ;
createNode polyMergeVert -n "polyMergeVert4";
	rename -uid "B14F3EF5-4ACC-5DC9-AE5F-AF979053A89C";
	setAttr ".ics" -type "componentList" 1 "vtx[0:5]";
	setAttr ".ix" -type "matrix" 7.5463225370164828 0 0 0 0 0.023443167178317518 0 0
		 0 0 7.5463225370164828 0 -75.463226318359119 0 0 1;
	setAttr ".d" 0.001;
	setAttr ".am" yes;
createNode polyTweak -n "polyTweak11";
	rename -uid "E2CE5058-4444-63C0-BBEA-CDACBA1CA3A5";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk";
	setAttr ".tk[0]" -type "float3" 9.9998999 0 0 ;
	setAttr ".tk[2]" -type "float3" -9.9999008 0 0 ;
	setAttr ".tk[3]" -type "float3" 9.9998999 0 0 ;
	setAttr ".tk[5]" -type "float3" -9.9999008 0 0 ;
createNode polyTweak -n "polyTweak12";
	rename -uid "9C47A15C-4AD0-71A1-8B50-59B965EFA5EF";
	setAttr ".uopa" yes;
	setAttr -s 45 ".tk";
	setAttr ".tk[0]" -type "float3" 0 9914.4063 -29.460142 ;
	setAttr ".tk[1]" -type "float3" 0 9914.4063 -29.460142 ;
	setAttr ".tk[2]" -type "float3" 1.6121641 3.1832315e-12 0 ;
	setAttr ".tk[3]" -type "float3" 0 0 0.24613233 ;
	setAttr ".tk[4]" -type "float3" 0 0 -2.1627617 ;
	setAttr ".tk[5]" -type "float3" 0 0 0.24613233 ;
	setAttr ".tk[6]" -type "float3" -1.6121641 3.1832315e-12 0 ;
	setAttr ".tk[7]" -type "float3" 9.96346 -888.03278 4.2351647e-22 ;
	setAttr ".tk[8]" -type "float3" 1.6121641 3.1832315e-12 4.2351647e-22 ;
	setAttr ".tk[9]" -type "float3" 0.90311658 209.18886 2.3841858e-07 ;
	setAttr ".tk[11]" -type "float3" -0.90311658 209.18886 2.3841858e-07 ;
	setAttr ".tk[12]" -type "float3" -1.6121641 3.1832315e-12 0 ;
	setAttr ".tk[13]" -type "float3" -9.96346 -888.03278 0 ;
	setAttr ".tk[14]" -type "float3" 1.6121641 3.1832315e-12 0 ;
	setAttr ".tk[15]" -type "float3" 0 0 -0.24613233 ;
	setAttr ".tk[17]" -type "float3" 0 0 -0.24613233 ;
	setAttr ".tk[18]" -type "float3" -1.6121641 3.1832315e-12 0 ;
	setAttr ".tk[27]" -type "float3" 1.6121641 3.1832315e-12 0 ;
	setAttr ".tk[28]" -type "float3" 0 0 -0.24613233 ;
	setAttr ".tk[30]" -type "float3" 0 0 -0.24613233 ;
	setAttr ".tk[31]" -type "float3" -1.6121641 3.1832315e-12 0 ;
	setAttr ".tk[32]" -type "float3" 9.96346 -888.03278 4.2351647e-22 ;
	setAttr ".tk[33]" -type "float3" 1.6121641 3.1832315e-12 4.2351647e-22 ;
	setAttr ".tk[34]" -type "float3" 0.90311658 209.18886 2.3841858e-07 ;
	setAttr ".tk[35]" -type "float3" 0 1107.3014 0 ;
	setAttr ".tk[36]" -type "float3" -0.90311658 209.18886 2.3841858e-07 ;
	setAttr ".tk[37]" -type "float3" -1.6121641 3.1832315e-12 0 ;
	setAttr ".tk[38]" -type "float3" -9.96346 -888.03278 0 ;
	setAttr ".tk[39]" -type "float3" 1.6121641 3.1832315e-12 0 ;
	setAttr ".tk[40]" -type "float3" 0 0 0.24613233 ;
	setAttr ".tk[41]" -type "float3" 0 0 -2.1627617 ;
	setAttr ".tk[42]" -type "float3" 0 0 0.24613233 ;
	setAttr ".tk[43]" -type "float3" -1.6121641 3.1832315e-12 0 ;
	setAttr ".tk[44]" -type "float3" 2.9571991 6.3664629e-12 0 ;
	setAttr ".tk[45]" -type "float3" 2.9571991 6.3664629e-12 0 ;
	setAttr ".tk[46]" -type "float3" -2.9571991 6.3664629e-12 0 ;
	setAttr ".tk[47]" -type "float3" -2.9571991 6.3664629e-12 0 ;
	setAttr ".tk[48]" -type "float3" 2.9571991 6.3664629e-12 0 ;
	setAttr ".tk[49]" -type "float3" 2.9571991 6.3664629e-12 0 ;
	setAttr ".tk[50]" -type "float3" -2.9571991 6.3664629e-12 0 ;
	setAttr ".tk[51]" -type "float3" -2.9571991 6.3664629e-12 0 ;
	setAttr ".tk[52]" -type "float3" 2.9571991 6.8212103e-12 4.2351647e-22 ;
	setAttr ".tk[53]" -type "float3" -2.9571991 6.8212103e-12 0 ;
	setAttr ".tk[54]" -type "float3" 2.9571991 6.8212103e-12 4.2351647e-22 ;
	setAttr ".tk[55]" -type "float3" -2.9571991 6.8212103e-12 0 ;
createNode polySplit -n "polySplit21";
	rename -uid "7549BE58-4DF8-962D-50C9-3F8F608A3FE4";
	setAttr -s 3 ".e[0:2]"  0.59555602 0.395235 0.40444401;
	setAttr -s 3 ".d[0:2]"  -2147483569 -2147483606 -2147483572;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit22";
	rename -uid "D6E62CF1-455A-BD67-4C50-D98E021C4B4A";
	setAttr -s 7 ".e[0:6]"  0 0.478064 0.51735699 0.66460401 0.48264301
		 0.521936 0;
	setAttr -s 7 ".d[0:6]"  -2147483516 -2147483640 -2147483573 -2147483601 -2147483568 -2147483641 
		-2147483514;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySoftEdge -n "polySoftEdge1";
	rename -uid "899CBACF-47EE-1E86-C80F-A2968B534C1E";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[135:136]" "e[142:147]";
	setAttr ".ix" -type "matrix" 7.5463225370164828 0 0 0 0 0.023443167178317518 0 0
		 0 0 7.0632618156223188 0 -75.463226318359119 0 0 1;
	setAttr ".a" 180;
createNode polyTweak -n "polyTweak13";
	rename -uid "802649A1-4E55-EEAC-961F-68919EAA0D0B";
	setAttr ".uopa" yes;
	setAttr -s 9 ".tk";
	setAttr ".tk[10]" -type "float3" 0 -26.326578 0 ;
	setAttr ".tk[56]" -type "float3" -0.099100992 1069.4847 -1.0809127 ;
	setAttr ".tk[57]" -type "float3" 0 1819.6144 -0.23482588 ;
	setAttr ".tk[58]" -type "float3" 0.099095128 1069.4847 -1.0809127 ;
	setAttr ".tk[59]" -type "float3" -0.043389924 1272.5826 0.032145083 ;
	setAttr ".tk[60]" -type "float3" -0.19799468 1362.3114 2.0179317 ;
	setAttr ".tk[61]" -type "float3" 0 2043.6891 -1.0306649 ;
	setAttr ".tk[62]" -type "float3" 0.19799176 1362.3114 2.0179317 ;
	setAttr ".tk[63]" -type "float3" 0.043392647 1272.5829 0.032145083 ;
createNode polySoftEdge -n "polySoftEdge2";
	rename -uid "0C695509-45BC-4196-2004-C6B1BCD847F6";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[135:136]" "e[142:147]";
	setAttr ".ix" -type "matrix" 7.5463225370164828 0 0 0 0 0.023443167178317518 0 0
		 0 0 7.0632618156223188 0 -75.463226318359119 0 0 1;
	setAttr ".a" 180;
createNode polySoftEdge -n "polySoftEdge3";
	rename -uid "3A7913F9-43A7-448F-494C-C7BC527B1728";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 8 "e[7:8]" "e[27:28]" "e[42]" "e[47]" "e[64]" "e[69]" "e[75:82]" "e[132:147]";
	setAttr ".ix" -type "matrix" 7.5463225370164828 0 0 0 0 0.023443167178317518 0 0
		 0 0 7.0632618156223188 0 -75.463226318359119 0 0 1;
	setAttr ".a" 180;
createNode polyCube -n "polyCube4";
	rename -uid "01B91E03-4176-9F51-D016-C0BC1B9D9E20";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".w" 1;
	setAttr ".h" 1;
	setAttr ".d" 1;
	setAttr ".sw" 3;
	setAttr ".sh" 3;
	setAttr ".cuv" 4;
createNode polySplitRing -n "polySplitRing5";
	rename -uid "7196AAF8-4258-CFBC-3F70-34AE9D71233C";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 8 "e[1]" "e[4]" "e[7]" "e[10]" "e[13]" "e[16]" "e[19]" "e[22]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".wt" 0.47744554281234741;
	setAttr ".re" 10;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak14";
	rename -uid "7FFEAD7E-4924-D938-4295-7291CC6AA023";
	setAttr ".uopa" yes;
	setAttr -s 24 ".tk";
	setAttr ".tk[1]" -type "float3" -29.83535 0 0 ;
	setAttr ".tk[2]" -type "float3" 29.83535 0 0 ;
	setAttr ".tk[4]" -type "float3" 0 -26.344196 0 ;
	setAttr ".tk[5]" -type "float3" -29.83535 -26.344196 0 ;
	setAttr ".tk[6]" -type "float3" 29.83535 -26.344196 0 ;
	setAttr ".tk[7]" -type "float3" 0 -26.344196 0 ;
	setAttr ".tk[8]" -type "float3" 0 23.818035 0 ;
	setAttr ".tk[9]" -type "float3" -29.83535 23.818035 0 ;
	setAttr ".tk[10]" -type "float3" 29.83535 23.818035 0 ;
	setAttr ".tk[11]" -type "float3" 0 23.818035 0 ;
	setAttr ".tk[13]" -type "float3" -29.83535 0 0 ;
	setAttr ".tk[14]" -type "float3" 29.83535 0 0 ;
	setAttr ".tk[17]" -type "float3" -29.83535 0 0 ;
	setAttr ".tk[18]" -type "float3" 29.83535 0 0 ;
	setAttr ".tk[20]" -type "float3" 0 23.818035 0 ;
	setAttr ".tk[21]" -type "float3" -29.83535 23.818035 0 ;
	setAttr ".tk[22]" -type "float3" 29.83535 23.818035 0 ;
	setAttr ".tk[23]" -type "float3" 0 23.818035 0 ;
	setAttr ".tk[24]" -type "float3" 0 -26.344196 0 ;
	setAttr ".tk[25]" -type "float3" -29.83535 -26.344196 0 ;
	setAttr ".tk[26]" -type "float3" 29.83535 -26.344196 0 ;
	setAttr ".tk[27]" -type "float3" 0 -26.344196 0 ;
	setAttr ".tk[29]" -type "float3" -29.83535 0 0 ;
	setAttr ".tk[30]" -type "float3" 29.83535 0 0 ;
createNode polyTweak -n "polyTweak15";
	rename -uid "C5FB42E1-4950-07A5-601E-7A9B912FEF5A";
	setAttr ".uopa" yes;
	setAttr -s 16 ".tk[32:47]" -type "float3"  17.50545502 0 0 17.50545502
		 0 0 17.50545502 0 0 17.50545502 0 0 17.50545502 0 0 17.50545502 0 0 17.50545502 0
		 0 17.50545502 0 0 -17.50546265 0 0 -17.50546265 0 0 -17.50546265 0 0 -17.50546265
		 0 0 -17.50546265 0 0 -17.50546265 0 0 -17.50546265 0 0 -17.50546265 0 0;
createNode deleteComponent -n "deleteComponent16";
	rename -uid "51469593-4DE4-A966-EC1B-A5B81214DC03";
	setAttr ".dc" -type "componentList" 3 "f[4]" "f[36]" "f[44]";
createNode polyExtrudeEdge -n "polyExtrudeEdge1";
	rename -uid "05E6E67E-4FB2-2164-E0B2-0DBEB115B8A8";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 7 "e[4]" "e[7]" "e[29:30]" "e[71]" "e[73]" "e[86]" "e[88]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.4179678e-07 4.4965296 -0.0055534123 ;
	setAttr ".rs" 45239;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -3.4570691795525326 -0.034723264093512396 -0.0055534127106577104 ;
	setAttr ".cbx" -type "double3" 3.4570688959589826 9.027782233962748 -0.0055534127106577104 ;
createNode polyExtrudeFace -n "polyExtrudeFace1";
	rename -uid "04494032-4C32-2BEE-4DA2-FF8ADE11B2D2";
	setAttr ".ics" -type "componentList" 1 "f[38]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -5.671871e-07 4.4965301 -4.3520489 ;
	setAttr ".rs" 55494;
	setAttr ".lt" -type "double3" 0 -1.8036966797323086e-17 0.14728301098636051 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.7837650605396109 -0.034722850050975466 -4.3520487156537841 ;
	setAttr ".cbx" -type "double3" 2.7837639261654119 9.0277826480052852 -4.3520487156537841 ;
createNode polyTweak -n "polyTweak16";
	rename -uid "20753DD7-4ABF-EAF0-6974-7C9D73515535";
	setAttr ".uopa" yes;
	setAttr -s 44 ".tk";
	setAttr ".tk[0]" -type "float3" 0 -1.3527496 0 ;
	setAttr ".tk[1]" -type "float3" 0 -1.3527496 0 ;
	setAttr ".tk[2]" -type "float3" 0 -1.3527496 0 ;
	setAttr ".tk[3]" -type "float3" 0 -1.3527496 0 ;
	setAttr ".tk[16]" -type "float3" 0 0 -3.6646023 ;
	setAttr ".tk[17]" -type "float3" 0 0 -3.6646023 ;
	setAttr ".tk[18]" -type "float3" 0 0 -3.6646023 ;
	setAttr ".tk[19]" -type "float3" 0 0 -3.6646023 ;
	setAttr ".tk[20]" -type "float3" 0 0 -3.6646023 ;
	setAttr ".tk[21]" -type "float3" 0 0 -3.6646023 ;
	setAttr ".tk[22]" -type "float3" 0 0 -3.6646023 ;
	setAttr ".tk[23]" -type "float3" 0 0 -3.6646023 ;
	setAttr ".tk[24]" -type "float3" 0 0 -3.6646023 ;
	setAttr ".tk[25]" -type "float3" 0 0 -3.6646023 ;
	setAttr ".tk[26]" -type "float3" 0 0 -3.6646023 ;
	setAttr ".tk[27]" -type "float3" 0 0 -3.6646023 ;
	setAttr ".tk[28]" -type "float3" 0 -1.3527496 -3.6646023 ;
	setAttr ".tk[29]" -type "float3" 0 -1.3527496 -3.6646023 ;
	setAttr ".tk[30]" -type "float3" 0 -1.3527496 -3.6646023 ;
	setAttr ".tk[31]" -type "float3" 0 -1.3527496 -3.6646023 ;
	setAttr ".tk[32]" -type "float3" 4.4390755 0 0 ;
	setAttr ".tk[33]" -type "float3" 4.4390755 0 -3.6646023 ;
	setAttr ".tk[34]" -type "float3" 4.4390755 0 -3.6646004 ;
	setAttr ".tk[35]" -type "float3" 4.4390755 0 -3.6646004 ;
	setAttr ".tk[36]" -type "float3" 4.4390755 -1.3527496 -3.6646023 ;
	setAttr ".tk[37]" -type "float3" 4.4390755 -1.3527496 0 ;
	setAttr ".tk[38]" -type "float3" 4.4390755 0 0 ;
	setAttr ".tk[39]" -type "float3" 4.4390755 0 0 ;
	setAttr ".tk[40]" -type "float3" -4.4390755 0 0 ;
	setAttr ".tk[41]" -type "float3" -4.4390755 0 -3.6646023 ;
	setAttr ".tk[42]" -type "float3" -4.4390755 0 -3.6646004 ;
	setAttr ".tk[43]" -type "float3" -4.4390755 0 -3.6646004 ;
	setAttr ".tk[44]" -type "float3" -4.4390755 -1.3527496 -3.6646023 ;
	setAttr ".tk[45]" -type "float3" -4.4390755 -1.3527496 0 ;
	setAttr ".tk[46]" -type "float3" -4.4390755 0 0 ;
	setAttr ".tk[47]" -type "float3" -4.4390755 0 0 ;
	setAttr ".tk[48]" -type "float3" 0 0 -98.931274 ;
	setAttr ".tk[49]" -type "float3" -4.4390755 0 -98.931274 ;
	setAttr ".tk[50]" -type "float3" 0 0 -98.931274 ;
	setAttr ".tk[51]" -type "float3" -4.4390755 0 -98.931274 ;
	setAttr ".tk[52]" -type "float3" 0 0 -98.931274 ;
	setAttr ".tk[53]" -type "float3" 0 0 -98.931274 ;
	setAttr ".tk[54]" -type "float3" 4.4390755 0 -98.931274 ;
	setAttr ".tk[55]" -type "float3" 4.4390755 0 -98.931274 ;
createNode polyCylinder -n "polyCylinder1";
	rename -uid "28AAA260-49AC-77C9-9A17-F3AD92394CC8";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".r" 1;
	setAttr ".h" 2;
	setAttr ".sc" 2;
	setAttr ".cuv" 3;
createNode polyCloseBorder -n "polyCloseBorder1";
	rename -uid "E48E56D1-4A1C-2B20-AD9F-0FABC0EEADCA";
	setAttr ".ics" -type "componentList" 5 "e[92]" "e[95:96]" "e[99]" "e[101]" "e[103:105]";
createNode polyTweak -n "polyTweak17";
	rename -uid "62A13C7E-402A-3BD5-8E95-71AC6490A258";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk[56:59]" -type "float3"  1.32089853 -1.47267437 0 1.32089853
		 1.47267413 0 -1.32089818 -1.47267437 0 -1.32089818 1.47267413 0;
createNode polyCube -n "polyCube5";
	rename -uid "EE602DA8-43F8-642D-AA9E-8D93F01CF95B";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".w" 1;
	setAttr ".h" 1;
	setAttr ".d" 1;
	setAttr ".cuv" 4;
createNode polyCube -n "polyCube6";
	rename -uid "97EE148F-486A-3DAF-DD8F-40A97FEC5AED";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".w" 1;
	setAttr ".h" 1;
	setAttr ".d" 1;
	setAttr ".cuv" 4;
createNode polySplitRing -n "polySplitRing6";
	rename -uid "9E57281A-4FA1-2415-8E36-EA96CD89C24B";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 8 "e[28:31]" "e[44:47]" "e[66]" "e[81]" "e[96]" "e[99]" "e[108]" "e[112]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".wt" 0.28886431455612183;
	setAttr ".re" 30;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak18";
	rename -uid "8B6F9F8E-4234-441D-9ABC-A9BE7443767D";
	setAttr ".uopa" yes;
	setAttr -s 30 ".tk";
	setAttr ".tk[0]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[1]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[2]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[3]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[4]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[5]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[6]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[7]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[24]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[25]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[26]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[27]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[28]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[29]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[30]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[31]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[35]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[36]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[37]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[38]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[43]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[44]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[45]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[46]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[48]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[49]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[52]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[54]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[57]" -type "float3" 0 -7.104053 0 ;
	setAttr ".tk[59]" -type "float3" 0 -7.104053 0 ;
createNode polyExtrudeFace -n "polyExtrudeFace2";
	rename -uid "0488DCDD-4080-E5D8-64F7-E395E8A4803F";
	setAttr ".ics" -type "componentList" 2 "f[25]" "f[68]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 3.7171171 5.0196333 -2.1788011 ;
	setAttr ".rs" 44905;
	setAttr ".lt" -type "double3" -1.605245442845543e-16 -6.8220385499067213e-17 0.5570617221762626 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 3.7171170912072391 -0.021295036533361442 -4.3520488755980953 ;
	setAttr ".cbx" -type "double3" 3.7171170912072391 10.060561243375139 -0.0055534127106577104 ;
createNode polyTweak -n "polyTweak19";
	rename -uid "B05C67CC-4CDE-3BCA-E7D3-EAB278384C28";
	setAttr ".uopa" yes;
	setAttr -s 14 ".tk[60:73]" -type "float3"  0 -38.072040558 0 0 -38.072040558
		 0 0 -38.072040558 0 0 -38.072040558 0 0 -38.072040558 0 0 -38.072040558 0 0 -38.072040558
		 0 0 -38.072040558 0 0 -38.072040558 0 0 -38.072040558 0 0 -38.072040558 0 0 -38.072040558
		 0 0 -38.072040558 0 0 -38.072040558 0;
createNode polySplitRing -n "polySplitRing7";
	rename -uid "AD9D806E-47EE-694C-C2CA-E79C775AB9DC";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 11 "e[44:47]" "e[65]" "e[80]" "e[107]" "e[111]" "e[113:114]" "e[116]" "e[118]" "e[120]" "e[138]" "e[152:153]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".wt" 0.56707704067230225;
	setAttr ".dr" no;
	setAttr ".re" 153;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak20";
	rename -uid "AA6A65EA-4659-1D3A-0438-AC86DC736978";
	setAttr ".uopa" yes;
	setAttr -s 6 ".tk[74:79]" -type "float3"  0 -2.46363759 4.53293228 0
		 -2.46363759 -4.53293228 0 -3.098442316 4.53293228 0 -3.098442316 -4.53293228 0 3.098442316
		 4.53293228 0 3.098442316 -4.53293228;
createNode polySplitRing -n "polySplitRing8";
	rename -uid "E95AF1C5-44EC-744C-BB83-E3A143B12F6B";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 15 "e[36:39]" "e[52:58]" "e[61]" "e[69]" "e[76]" "e[84]" "e[123]" "e[139]" "e[143]" "e[147]" "e[151]" "e[168]" "e[185]" "e[200]" "e[217]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".wt" 0.79679787158966064;
	setAttr ".dr" no;
	setAttr ".re" 185;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak21";
	rename -uid "A9EDC976-4760-6CA2-1B4F-0C9897D24EC7";
	setAttr ".uopa" yes;
	setAttr -s 32 ".tk[80:111]" -type "float3"  0 2.20674515 0 0 1.59713507
		 0 0 1.59713507 0 0 1.59713507 0 0 1.59713507 0 0 1.59713507 0 0 1.59713507 0 0 1.59713507
		 0 0 1.59713507 0 0 1.59713507 0 0 2.57891417 0 0 2.57891417 0 0 1.59713507 0 0 1.59713507
		 0 0 1.59713507 0 0 2.20674515 0 0 4.93242407 0 0 6.17682838 0 0 6.17682838 0 0 6.17682838
		 0 0 6.17682838 0 0 6.17682838 0 0 6.17682838 0 0 6.17682838 0 0 6.17682838 0 0 6.17682838
		 0 0 6.66771221 0 0 6.66771221 0 0 6.17682838 0 0 6.17682838 0 0 6.17682838 0 0 4.93242407
		 0;
createNode polySplitRing -n "polySplitRing9";
	rename -uid "F69A9EB3-4C8C-08B4-F8BC-E99A31F236E1";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 11 "e[89:90]" "e[92:93]" "e[96:97]" "e[99]" "e[101]" "e[115]" "e[119]" "e[160]" "e[164]" "e[192]" "e[196]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".wt" 0.59501498937606812;
	setAttr ".dr" no;
	setAttr ".re" 160;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak22";
	rename -uid "41510707-469D-53D8-83F1-7A8AB9236AF2";
	setAttr ".uopa" yes;
	setAttr -s 24 ".tk[136:159]" -type "float3"  0 0 -17.41675186 0 0 -17.41675186
		 0 0 -17.41675186 0 0 -17.41675186 0 0 -17.41675186 0 0 -17.41675186 0 0 -17.41675186
		 0 0 -17.41675186 0 0 -17.41675186 0 0 -17.41675186 0 0 -17.41675186 0 0 -17.41675186
		 0 0 -17.41675186 0 0 -17.41675186 0 0 -17.41675186 0 0 -17.41675186 0 0 -17.41675186
		 0 0 -17.41675186 0 0 -17.41675186 0 0 -17.41675186 0 0 -17.41675186 0 0 -17.41675186
		 0 0 -17.41675186 0 0 -17.41675186;
createNode polyTweak -n "polyTweak23";
	rename -uid "6FD5E4AE-488C-3939-0CA2-E6AF33FFE2EE";
	setAttr ".uopa" yes;
	setAttr -s 76 ".tk[112:187]" -type "float3"  0 0 0.75101072 0 0 0.75101072
		 0 0 0.75101072 0 0 -0.7599678 0 0 -0.7599678 0 0 -0.7599678 0 0 -0.7599678 0 0 -0.7599678
		 0 0 -0.7599678 0 0 -0.7599678 0 0 -0.7599678 0 0 -0.7599678 0 0 -0.7599678 0 0 -0.75997013
		 0 0 -0.75997013 0 0 -0.7599678 0 0 -0.7599678 0 0 -0.7599678 0 0 -0.7599678 0 0 -0.7599678
		 0 0 -0.7599678 0 0 -0.7599678 0 0 0.75101072 0 0 0.75101072 0 0 -0.51797342 0 0 -0.51797342
		 0 0 -0.51797342 0 0 0.99299264 0 0 0.99299264 0 0 0.99299264 0 0 0.99299264 0 0 0.99299264
		 0 0 0.99299264 0 0 0.99299264 0 0 0.99299264 0 0 0.99299264 0 0 0.99299264 0 0 0.99299002
		 0 0 0.99299002 0 0 0.99299264 0 0 0.99299264 0 0 0.99299264 0 0 0.99299264 0 0 0.99299264
		 0 0 0.99299264 0 0 0.99299264 0 0 -0.51797342 0 0 -0.51797342 0 0 -19.57929802 0
		 0 -19.57929802 0 0 -19.57929802 0 0 -19.57929802 0 0 -19.57929802 0 0 -19.57929802
		 0 0 -19.57929802 0 0 -19.57929802 0 0 -19.57929802 0 0 -19.57929802 0 0 -19.57929802
		 0 0 -19.57929802 0 0 -19.57929802 0 0 -19.57929802 0 0 -2.33774734 0 0 -2.33774734
		 0 0 -2.33774734 0 0 -2.33774734 0 0 -2.33774734 0 0 -2.33774734 0 0 -2.33774734 0
		 0 -2.33774734 0 0 -2.33774734 0 0 -2.33774734 0 0 -2.33774734 0 0 -2.33774734 0 0
		 -2.33774734 0 0 -2.33774734;
createNode deleteComponent -n "deleteComponent17";
	rename -uid "91FEFD27-428D-1A2B-26AB-3A8CCC9AC7C2";
	setAttr ".dc" -type "componentList" 2 "f[132]" "f[170]";
createNode polyBridgeEdge -n "polyBridgeEdge3";
	rename -uid "A31D445C-41F4-7AB4-5556-FF9AC05A91A3";
	setAttr ".ics" -type "componentList" 4 "e[220]" "e[266:268]" "e[316]" "e[342:344]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 113;
	setAttr ".sv2" 175;
	setAttr ".d" 1;
	setAttr ".sd" 1;
	setAttr ".td" 1;
createNode polyBevel3 -n "polyBevel1";
	rename -uid "0A5954AA-420A-366D-DB24-079FFB88E542";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[9]";
	setAttr ".ix" -type "matrix" 2.1925925106954645 0 0 0 0 2.5 0 0 0 0 2.0709075706945392 0
		 443.99001096752431 491.18474381883118 -253.41843168325786 1;
	setAttr ".ws" yes;
	setAttr ".oaf" yes;
	setAttr ".f" 0.70000000000000007;
	setAttr ".sg" 4;
	setAttr ".at" 180;
	setAttr ".sn" yes;
	setAttr ".mv" yes;
	setAttr ".mvt" 0.0001;
	setAttr ".sa" 30;
createNode polyBevel3 -n "polyBevel2";
	rename -uid "2D1B9706-43D8-B95B-92CA-81ACFF808D4F";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 20 "e[36]" "e[52]" "e[55]" "e[89]" "e[92]" "e[96:97]" "e[227]" "e[237]" "e[249]" "e[275]" "e[285]" "e[297]" "e[319]" "e[325]" "e[333]" "e[339]" "e[347]" "e[353]" "e[361]" "e[367]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".ws" yes;
	setAttr ".oaf" yes;
	setAttr ".f" 1;
	setAttr ".sg" 2;
	setAttr ".at" 180;
	setAttr ".sn" yes;
	setAttr ".mv" yes;
	setAttr ".mvt" 0.0001;
	setAttr ".sa" 30;
createNode polyExtrudeFace -n "polyExtrudeFace3";
	rename -uid "8462172C-480B-B759-0557-D0AFBDCC4A50";
	setAttr ".ics" -type "componentList" 1 "f[60:79]";
	setAttr ".ix" -type "matrix" 2.3350839049201033 0 0 0 0 1.0696933426487639e-16 0.48174705393536732 0
		 0 -2.3350839049201033 5.1849278313478371e-16 0 0 350.15220839606241 -495.03759521228426 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.3361458e-07 3.4915502 -4.8408055 ;
	setAttr ".rs" 38286;
	setAttr ".lt" -type "double3" 0 -5.3603417531852023e-16 -0.26456618603925736 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -1.0884612767806734 2.4030891516113972 -4.8408058058594037 ;
	setAttr ".cbx" -type "double3" 1.0884610095515279 4.5800115270199813 -4.8408058058594028 ;
createNode polyTweak -n "polyTweak24";
	rename -uid "A2F2B012-4535-935D-AAA9-59ACA885EAE6";
	setAttr ".uopa" yes;
	setAttr -s 61 ".tk";
	setAttr ".tk[0]" -type "float3" -3.2208934 122.74433 1.4735796 ;
	setAttr ".tk[1]" -type "float3" -2.7398572 122.74433 2.4176683 ;
	setAttr ".tk[2]" -type "float3" -1.9906201 122.74433 3.1669018 ;
	setAttr ".tk[3]" -type "float3" -1.0465319 122.74433 3.6479394 ;
	setAttr ".tk[4]" -type "float3" -3.8757091e-07 122.74433 3.8136971 ;
	setAttr ".tk[5]" -type "float3" 1.0465301 122.74433 3.6479402 ;
	setAttr ".tk[6]" -type "float3" 1.9906234 122.74433 3.1669028 ;
	setAttr ".tk[7]" -type "float3" 2.7398548 122.74433 2.4176681 ;
	setAttr ".tk[8]" -type "float3" 3.2208915 122.74433 1.4735783 ;
	setAttr ".tk[9]" -type "float3" 3.3866429 122.74433 0.42704737 ;
	setAttr ".tk[10]" -type "float3" 3.2208915 122.74433 -0.61948395 ;
	setAttr ".tk[11]" -type "float3" 2.7398543 122.74433 -1.5635753 ;
	setAttr ".tk[12]" -type "float3" 1.9906216 122.74433 -2.3128076 ;
	setAttr ".tk[13]" -type "float3" 1.0465305 122.74433 -2.7938454 ;
	setAttr ".tk[14]" -type "float3" -2.8664098e-07 122.74433 -2.9596004 ;
	setAttr ".tk[15]" -type "float3" -1.0465314 122.74433 -2.7938426 ;
	setAttr ".tk[16]" -type "float3" -1.9906234 122.74433 -2.3128066 ;
	setAttr ".tk[17]" -type "float3" -2.7398548 122.74433 -1.5635738 ;
	setAttr ".tk[18]" -type "float3" -3.2208915 122.74433 -0.61948335 ;
	setAttr ".tk[19]" -type "float3" -3.3866429 122.74433 0.42704737 ;
	setAttr ".tk[20]" -type "float3" -13.586615 122.74433 4.8565741 ;
	setAttr ".tk[21]" -type "float3" -11.557468 122.74433 8.8390055 ;
	setAttr ".tk[22]" -type "float3" -8.3969917 122.74433 11.99948 ;
	setAttr ".tk[23]" -type "float3" -4.4145579 122.74433 14.028631 ;
	setAttr ".tk[24]" -type "float3" -1.6348803e-06 122.74433 14.727826 ;
	setAttr ".tk[25]" -type "float3" 4.414556 122.74433 14.028624 ;
	setAttr ".tk[26]" -type "float3" 8.396986 122.74433 11.999476 ;
	setAttr ".tk[27]" -type "float3" 11.55746 122.74433 8.8390007 ;
	setAttr ".tk[28]" -type "float3" 13.586606 122.74433 4.8565707 ;
	setAttr ".tk[29]" -type "float3" 14.285807 122.74433 0.44201538 ;
	setAttr ".tk[30]" -type "float3" 13.586606 122.74433 -3.9725404 ;
	setAttr ".tk[31]" -type "float3" 11.557461 122.74433 -7.9549699 ;
	setAttr ".tk[32]" -type "float3" 8.3969822 122.74433 -11.115442 ;
	setAttr ".tk[33]" -type "float3" 4.4145546 122.74433 -13.144587 ;
	setAttr ".tk[34]" -type "float3" -1.2091301e-06 122.74433 -13.843789 ;
	setAttr ".tk[35]" -type "float3" -4.4145579 122.74433 -13.144591 ;
	setAttr ".tk[36]" -type "float3" -8.396986 122.74433 -11.115439 ;
	setAttr ".tk[37]" -type "float3" -11.557457 122.74433 -7.9549699 ;
	setAttr ".tk[38]" -type "float3" -13.586606 122.74433 -3.9725394 ;
	setAttr ".tk[39]" -type "float3" -14.285803 122.74433 0.44201538 ;
	setAttr ".tk[60]" -type "float3" -3.2208934 0 1.061501 ;
	setAttr ".tk[61]" -type "float3" -2.7398572 0 2.0055914 ;
	setAttr ".tk[62]" -type "float3" -1.9906201 0 2.7548258 ;
	setAttr ".tk[63]" -type "float3" -1.0465319 0 3.2358613 ;
	setAttr ".tk[64]" -type "float3" -3.8757091e-07 0 3.4016171 ;
	setAttr ".tk[65]" -type "float3" 1.046531 0 3.2358623 ;
	setAttr ".tk[66]" -type "float3" 1.9906224 0 2.7548232 ;
	setAttr ".tk[67]" -type "float3" 2.7398548 0 2.0055885 ;
	setAttr ".tk[68]" -type "float3" 3.2208915 0 1.0615009 ;
	setAttr ".tk[69]" -type "float3" 3.3866429 0 0.014969012 ;
	setAttr ".tk[70]" -type "float3" 3.2208915 0 -1.0315622 ;
	setAttr ".tk[71]" -type "float3" 2.7398543 0 -1.9756504 ;
	setAttr ".tk[72]" -type "float3" 1.9906216 0 -2.7248859 ;
	setAttr ".tk[73]" -type "float3" 1.0465305 0 -3.2059221 ;
	setAttr ".tk[74]" -type "float3" -2.8664098e-07 0 -3.3716781 ;
	setAttr ".tk[75]" -type "float3" -1.0465314 0 -3.2059231 ;
	setAttr ".tk[76]" -type "float3" -1.9906224 0 -2.7248862 ;
	setAttr ".tk[77]" -type "float3" -2.7398548 0 -1.9756509 ;
	setAttr ".tk[78]" -type "float3" -3.2208915 0 -1.0315617 ;
	setAttr ".tk[79]" -type "float3" -3.3866429 0 0.014969012 ;
	setAttr ".tk[80]" -type "float3" -2.9017496e-21 122.74433 0.44201753 ;
createNode polyExtrudeFace -n "polyExtrudeFace4";
	rename -uid "8BAD4253-40E3-4E6F-9F79-5692D4F8917A";
	setAttr ".ics" -type "componentList" 1 "f[80:99]";
	setAttr ".ix" -type "matrix" 2.3350839049201033 0 0 0 0 1.0696933426487639e-16 0.48174705393536732 0
		 0 -2.3350839049201033 5.1849278313478371e-16 0 0 350.15220839606241 -495.03759521228426 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.3361458e-07 3.5011728 -4.4686289 ;
	setAttr ".rs" 35651;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -1.0884612767806734 2.4127115386866347 -4.4686288981874753 ;
	setAttr ".cbx" -type "double3" 1.0884610095515279 4.5896342704007456 -4.4686288981874744 ;
createNode polyExtrudeFace -n "polyExtrudeFace5";
	rename -uid "9B895455-428C-3FB3-2290-119D0894C719";
	setAttr ".ics" -type "componentList" 1 "f[80:99]";
	setAttr ".ix" -type "matrix" 2.3350839049201033 0 0 0 0 1.0696933426487639e-16 0.48174705393536732 0
		 0 -2.3350839049201033 5.1849278313478371e-16 0 0 350.15220839606241 -495.03759521228426 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.3361458e-07 3.501173 -4.0084562 ;
	setAttr ".rs" 53352;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -1.0884612767806734 2.4127117168393983 -4.0084562997566797 ;
	setAttr ".cbx" -type "double3" 1.0884610095515279 4.5896342704007456 -4.0084562997566788 ;
createNode polyTweak -n "polyTweak25";
	rename -uid "471C098C-4681-D979-7653-028DDC7EED07";
	setAttr ".uopa" yes;
	setAttr -s 21 ".tk[101:121]" -type "float3"  0 95.5216217 3.5527137e-15
		 0 95.5216217 0 -1.4509679e-21 95.5216217 4.3758099e-15 0 95.5216217 0 0 95.5216217
		 0 -1.4823077e-21 95.5216217 0 0 95.5216217 0 0 95.5216217 0 0 95.5216217 0 0 95.5216217
		 3.5527137e-15 0 95.5216217 4.3784421e-15 0 95.5216217 3.5527137e-15 0 95.5216217
		 0 0 95.5216217 0 0 95.5216217 0 -1.2705494e-21 95.5216217 0 0 95.5216217 0 0 95.5216217
		 0 0 95.5216217 0 0 95.5216217 3.5527137e-15 0 95.5216217 4.3784421e-15;
createNode polySoftEdge -n "polySoftEdge4";
	rename -uid "08ADA05F-4C8F-9424-53DF-BD825EBBD0D3";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 38 "e[200:201]" "e[203]" "e[205]" "e[207]" "e[209]" "e[211]" "e[213]" "e[215]" "e[217]" "e[219]" "e[221]" "e[223]" "e[225]" "e[227]" "e[229]" "e[231]" "e[233]" "e[235]" "e[237]" "e[240:241]" "e[245]" "e[248]" "e[251]" "e[254]" "e[257]" "e[260]" "e[263]" "e[266]" "e[269]" "e[272]" "e[275]" "e[278]" "e[281]" "e[284]" "e[287]" "e[290]" "e[293]" "e[296]";
	setAttr ".ix" -type "matrix" 2.3350839049201033 0 0 0 0 1.0696933426487639e-16 0.48174705393536732 0
		 0 -2.3350839049201033 5.1849278313478371e-16 0 0 350.15220839606241 -495.03759521228426 1;
	setAttr ".a" 180;
createNode polyTweak -n "polyTweak26";
	rename -uid "B198E981-44A9-7810-EF93-738F40F7ED57";
	setAttr ".uopa" yes;
	setAttr -s 41 ".tk[101:141]" -type "float3"  0 -9.6000042 0 0 -9.6000042
		 0 0 -9.6000042 0 0 -9.6000042 0 -7.4115383e-22 -9.6000042 0 0 -9.6000042 0 0 -9.6000042
		 0 0 -9.6000042 0 0 -9.6000042 0 0 -9.6000042 -4.4235449e-16 0 -9.6000042 0 0 -9.6000042
		 0 0 -9.6000042 0 0 -9.6000042 0 -6.3527471e-22 -9.6000042 0 0 -9.6000042 0 0 -9.6000042
		 0 0 -9.6000042 0 0 -9.6000042 0 0 -9.6000042 -4.4235449e-16 -5.89504051 23.41248512
		 1.91541755 -5.014621735 23.41248512 3.64333677 -7.6088867e-07 23.41248512 0.0019874412
		 -3.64333582 23.41248512 5.014620304 -1.91541517 23.41248512 5.89504004 -7.0935153e-07
		 23.41248512 6.19841003 1.9154135 23.41248512 5.89504004 3.64333391 23.41248512 5.014620304
		 5.014618397 23.41248512 3.64333677 5.89503717 23.41248512 1.91541576 6.19840956 23.41248512
		 3.043569e-06 5.89503717 23.41248512 -1.9154135 5.014618397 23.41248512 -3.64333344
		 3.64333272 23.41248512 -5.014619827 1.91541338 23.41248512 -5.89503765 -5.2462451e-07
		 23.41248512 -6.19841003 -1.91541409 23.41248512 -5.8950367 -3.64333391 23.41248512
		 -5.014619827 -5.014618874 23.41248512 -3.64333344 -5.89503717 23.41248512 -1.9154135
		 -6.19840956 23.41248512 3.043569e-06;
createNode polyCube -n "polyCube7";
	rename -uid "95EC1173-4D4E-9353-E7ED-7489400A54BC";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".w" 1;
	setAttr ".h" 1;
	setAttr ".d" 1;
	setAttr ".cuv" 4;
createNode polyTweak -n "polyTweak27";
	rename -uid "0C3641F3-4627-3CC5-AFF0-AE969085F0EC";
	setAttr ".uopa" yes;
	setAttr -s 17 ".tk";
	setAttr ".tk[1]" -type "float3" -4.7683716e-07 0 0 ;
	setAttr ".tk[3]" -type "float3" -4.7683716e-07 0 0 ;
	setAttr ".tk[5]" -type "float3" 3.8146973e-06 0 0 ;
	setAttr ".tk[6]" -type "float3" -1.7052078 0 -3.6108093 ;
	setAttr ".tk[7]" -type "float3" 4.0531158e-06 2.1316282e-14 -4.8144116 ;
	setAttr ".tk[8]" -type "float3" 5.8439088 0 -5.3279266 ;
	setAttr ".tk[9]" -type "float3" -9.5367432e-07 0 0 ;
	setAttr ".tk[10]" -type "float3" -1.1368058 0 -4.8144116 ;
	setAttr ".tk[11]" -type "float3" -1.1368058 0 -4.8144116 ;
	setAttr ".tk[12]" -type "float3" 4.7683716e-07 0 0 ;
	setAttr ".tk[13]" -type "float3" 5.8439088 0 -5.3279266 ;
	setAttr ".tk[14]" -type "float3" -2.4868996e-14 2.1316282e-14 -4.8144116 ;
	setAttr ".tk[15]" -type "float3" -1.7052078 0 -3.6108093 ;
	setAttr ".tk[20]" -type "float3" -9.5367432e-07 0 0 ;
	setAttr ".tk[21]" -type "float3" 4.7683716e-07 0 0 ;
	setAttr ".tk[28]" -type "float3" 4.7683716e-07 0 0 ;
	setAttr ".tk[29]" -type "float3" -9.5367432e-07 0 0 ;
createNode polySplit -n "polySplit23";
	rename -uid "B9C8D5A7-4BBC-E991-38CF-F1BF5AF5F732";
	setAttr -s 7 ".e[0:6]"  0 1 1 0 1 1 0;
	setAttr -s 7 ".d[0:6]"  -2147483647 -2147483641 -2147483629 -2147483647 -2147483632 -2147483635 
		-2147483647;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit24";
	rename -uid "BDCE3615-4A1A-BE36-5F02-3B9536142613";
	setAttr -s 3 ".e[0:2]"  0 0 0;
	setAttr -s 3 ".d[0:2]"  -2147483638 -2147483648 -2147483627;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit25";
	rename -uid "12DD7FDF-4C32-1533-461B-D58F6AF60D74";
	setAttr -s 4 ".e[0:3]"  0 1 0 1;
	setAttr -s 4 ".d[0:3]"  -2147483630 -2147483639 -2147483633 -2147483637;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit26";
	rename -uid "E45B4A8D-4D68-FF45-1FAE-BBB9E67B62FA";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483645 -2147483639;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweakUV -n "polyTweakUV3";
	rename -uid "AB5A1AFB-4EA8-5DEC-ECA5-1C91E3232C8D";
	setAttr ".uopa" yes;
	setAttr -s 3 ".uvtk";
	setAttr ".uvtk[146]" -type "float2" 0.070109576 -0.010879661 ;
	setAttr ".uvtk[282]" -type "float2" -0.028466359 0 ;
	setAttr ".uvtk[351]" -type "float2" -0.0012465589 0 ;
createNode polyMergeVert -n "polyMergeVert5";
	rename -uid "42E1A186-4D97-114E-6F70-AD95D3B052DA";
	setAttr ".ics" -type "componentList" 2 "vtx[174]" "vtx[240]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak28";
	rename -uid "030C607E-419F-DCDF-2595-EDB029815852";
	setAttr ".uopa" yes;
	setAttr ".tk[174]" -type "float3"  2.98541641 0 0;
createNode polyTweakUV -n "polyTweakUV4";
	rename -uid "102BF3CF-477F-9AA6-D12F-4884E8999583";
	setAttr ".uopa" yes;
	setAttr -s 4 ".uvtk";
	setAttr ".uvtk[146]" -type "float2" -8.3313818e-05 -0.00026561302 ;
	setAttr ".uvtk[259]" -type "float2" -0.0229767 0.018096138 ;
	setAttr ".uvtk[281]" -type "float2" -0.012950611 0 ;
	setAttr ".uvtk[282]" -type "float2" -0.011443655 0 ;
createNode polyMergeVert -n "polyMergeVert6";
	rename -uid "80893438-49E2-8E73-86D6-76BAFA89002C";
	setAttr ".ics" -type "componentList" 1 "vtx[174:175]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak29";
	rename -uid "0F27B742-41C3-8DD9-6B82-78941CC79EDF";
	setAttr ".uopa" yes;
	setAttr ".tk[175]" -type "float3"  0 2.044826508 0;
createNode polyTweakUV -n "polyTweakUV5";
	rename -uid "ADA5B9D7-446C-7318-4EB2-12B190BED3A0";
	setAttr ".uopa" yes;
	setAttr -s 3 ".uvtk";
	setAttr ".uvtk[157]" -type "float2" 0.032487433 0.020402953 ;
	setAttr ".uvtk[286]" -type "float2" -0.047333166 0 ;
	setAttr ".uvtk[350]" -type "float2" -0.041276254 0 ;
createNode polyMergeVert -n "polyMergeVert7";
	rename -uid "BFF8CCDF-4BEC-7FF1-5B5F-16848B679D9C";
	setAttr ".ics" -type "componentList" 2 "vtx[189]" "vtx[240]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak30";
	rename -uid "4D6F8025-439E-B04D-7240-6AAD6C050332";
	setAttr ".uopa" yes;
	setAttr ".tk[189]" -type "float3"  0 2.044826508 0;
createNode polyTweakUV -n "polyTweakUV6";
	rename -uid "96DFA55B-419F-98AE-7423-11B3C5394949";
	setAttr ".uopa" yes;
	setAttr -s 4 ".uvtk";
	setAttr ".uvtk[157]" -type "float2" 0.0077942973 -9.8725628e-05 ;
	setAttr ".uvtk[257]" -type "float2" -0.061860677 -0.010029892 ;
	setAttr ".uvtk[285]" -type "float2" -0.021462148 0 ;
	setAttr ".uvtk[286]" -type "float2" -0.036293194 0 ;
createNode polyMergeVert -n "polyMergeVert8";
	rename -uid "0FA43B6F-48D5-18E3-6EF0-04B779AD17F8";
	setAttr ".ics" -type "componentList" 1 "vtx[189:190]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak31";
	rename -uid "A6623AC2-45F0-E788-ABC2-87A9FB2B2871";
	setAttr ".uopa" yes;
	setAttr ".tk[190]" -type "float3"  -2.98542023 0 0;
createNode polySplit -n "polySplit27";
	rename -uid "1D7D2396-4E04-F0A0-9D95-9E830B0A2CDB";
	setAttr -s 5 ".e[0:4]"  0 0.902619 0.902619 0.902619 0;
	setAttr -s 5 ".d[0:4]"  -2147483573 -2147483559 -2147483482 -2147483514 -2147483572;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit28";
	rename -uid "9499458B-49E8-8717-07E6-D8A796DF46FD";
	setAttr -s 5 ".e[0:4]"  1 0.097380802 0.097380802 0.097380802 0;
	setAttr -s 5 ".d[0:4]"  -2147483573 -2147483559 -2147483482 -2147483514 -2147483574;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweak -n "polyTweak32";
	rename -uid "75C14CED-49CB-D39B-375B-33B77AF61DE6";
	setAttr ".uopa" yes;
	setAttr -s 3 ".tk[243:245]" -type "float3"  -0.88197076 0 0 -0.88197243
		 0 0 -0.88197315 0 0;
createNode polySplit -n "polySplit29";
	rename -uid "78C7B892-41AF-5E1D-B012-76A46F0B8FB7";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483559 -2147483576;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit30";
	rename -uid "050ADD91-4A8D-D619-0AA5-94BB2EE1832C";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483176 -2147483244;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit31";
	rename -uid "98CD83FA-4652-4680-E61C-7FB0CC17EA7D";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483559 -2147483251;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit32";
	rename -uid "BA586B75-44BE-055B-6971-ABA09707C926";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483179 -2147483244;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit33";
	rename -uid "26078034-41F5-EB3E-BB06-A68595B1F774";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483559 -2147483251;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit34";
	rename -uid "52E54A99-475B-30F9-E7BE-C88ACBE6315A";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483179 -2147483321;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit35";
	rename -uid "ECD72347-4D93-579D-9C4E-2F95117753EF";
	setAttr -s 4 ".e[0:3]"  0 0.90854001 0.90854001 1;
	setAttr -s 4 ".d[0:3]"  -2147483237 -2147483173 -2147483166 -2147483517;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit36";
	rename -uid "6CF0FD83-425B-0028-F0FA-5A8FB987E76C";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483158 -2147483230;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit37";
	rename -uid "C7616837-438E-98D6-3422-678956DE9890";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483157 -2147483320;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit38";
	rename -uid "9CF2934B-4695-F95C-F0F8-BEA5B0E6CF9E";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483155 -2147483230;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit39";
	rename -uid "BBFC3835-436D-BCC5-846C-618C989C0AA2";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483157 -2147483237;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit40";
	rename -uid "B7AD1F36-4F38-D227-09A2-E7A83E9DE153";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483634 -2147483325;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit41";
	rename -uid "1A3666A1-4731-33EC-3457-6380B3C8AB14";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483335 -2147483266;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit42";
	rename -uid "30227AF3-46AA-AF4D-597E-5285354C2A6C";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483634 -2147483260;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit43";
	rename -uid "F26D6677-4098-43F5-55DD-49B6F71504C8";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483633 -2147483266;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit44";
	rename -uid "D6FE1263-4ECF-3F53-246E-C294F9AF6BE5";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483616 -2147483615;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit45";
	rename -uid "26239A50-4CA9-D99E-5D95-9D9159EABC94";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483638 -2147483310;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit46";
	rename -uid "18EDBEE9-42C4-4354-65F7-A18EBAE446A0";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483616 -2147483303;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit47";
	rename -uid "1070498F-4D92-AEBE-AC0A-C2A714199AD2";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483617 -2147483308;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit48";
	rename -uid "7563934B-4536-7F16-1864-BA8B1575A05C";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483625 -2147483254;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit49";
	rename -uid "411243B2-4887-925E-B943-4B8667F6919B";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483641 -2147483324;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit50";
	rename -uid "93DE832E-4448-21D5-63FE-C8900BCEA97C";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483342 -2147483632;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit51";
	rename -uid "1F5A229E-4A6F-FD39-1B76-9494C3D6D3BB";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483334 -2147483335;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit52";
	rename -uid "80021D4D-4142-00C7-3959-26A5F20565F8";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483343 -2147483634;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit53";
	rename -uid "9C165AF2-41F9-4A8A-816E-6C87FE690ABE";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483333 -2147483600;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweakUV -n "polyTweakUV7";
	rename -uid "381BD2FC-40EB-E4A7-3AC5-BAA0257C3A51";
	setAttr ".uopa" yes;
	setAttr -s 6 ".uvtk";
	setAttr ".uvtk[162]" -type "float2" -0.071122125 0.028650261 ;
	setAttr ".uvtk[252]" -type "float2" 0.069115974 0.032087352 ;
	setAttr ".uvtk[281]" -type "float2" 0.0022838877 5.874938e-11 ;
	setAttr ".uvtk[287]" -type "float2" -0.0026183052 0 ;
	setAttr ".uvtk[347]" -type "float2" -0.041276321 -1.0617702e-09 ;
	setAttr ".uvtk[348]" -type "float2" -0.00011463447 0 ;
createNode polyMergeVert -n "polyMergeVert9";
	rename -uid "572DD16B-423C-94EE-8C8F-DCB12EC5BD24";
	setAttr ".ics" -type "componentList" 3 "vtx[183]" "vtx[195]" "vtx[238:239]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak33";
	rename -uid "D1A67E47-4E8D-CCFB-6C85-E3A17A494FA1";
	setAttr ".uopa" yes;
	setAttr -s 32 ".tk";
	setAttr ".tk[38]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[39]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[40]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[41]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[47]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[48]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[69]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[70]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[85]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[86]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[183]" -type "float3" 2.9854164 0 0 ;
	setAttr ".tk[195]" -type "float3" -2.9854202 0 0 ;
	setAttr ".tk[214]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[215]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[216]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[220]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[221]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[222]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[226]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[227]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[228]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[232]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[233]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[234]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[240]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[241]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[242]" -type "float3" 0 0 1.9980178e-07 ;
	setAttr ".tk[243]" -type "float3" 0 0 -1.9980178e-07 ;
	setAttr ".tk[244]" -type "float3" 0 0 -1.9980178e-07 ;
	setAttr ".tk[245]" -type "float3" 0 0 -1.9980178e-07 ;
	setAttr ".tk[246]" -type "float3" -2.3841858e-06 0 1.9980178e-07 ;
	setAttr ".tk[247]" -type "float3" -1.9073486e-06 0 1.9980178e-07 ;
createNode polyTweakUV -n "polyTweakUV8";
	rename -uid "27AC7FFE-4263-E0E6-243B-EA9A56316B0D";
	setAttr ".uopa" yes;
	setAttr -s 8 ".uvtk";
	setAttr ".uvtk[153]" -type "float2" -0.022579852 -0.011334781 ;
	setAttr ".uvtk[162]" -type "float2" -4.8012911e-08 0.0012354166 ;
	setAttr ".uvtk[164]" -type "float2" 0.019412264 -0.011967064 ;
	setAttr ".uvtk[252]" -type "float2" -0.00012815552 0.00095056393 ;
	setAttr ".uvtk[281]" -type "float2" 0.035137855 9.0386898e-10 ;
	setAttr ".uvtk[282]" -type "float2" 0.042982992 1.1056737e-09 ;
	setAttr ".uvtk[286]" -type "float2" -0.0011911765 0 ;
	setAttr ".uvtk[287]" -type "float2" -0.001052598 0 ;
createNode polyMergeVert -n "polyMergeVert10";
	rename -uid "5D3750D4-46CB-7195-9810-3D9B1DE2A434";
	setAttr ".ics" -type "componentList" 2 "vtx[182:183]" "vtx[195:196]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak34";
	rename -uid "371574F3-4D51-8C7F-1CDB-DCA3366A9514";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[182]" -type "float3" 0 -2.0448303 0 ;
	setAttr ".tk[196]" -type "float3" 0 -2.0448303 0 ;
createNode polySplit -n "polySplit54";
	rename -uid "0CCC508A-4513-45E6-F07D-92B98C6ABEFE";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483337 -2147483645;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit55";
	rename -uid "369A259D-4710-E7FB-031F-40A4566347F8";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483596 -2147483609;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit56";
	rename -uid "D4B81E70-4B3B-223A-B0C8-0A8DAA185892";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483513 -2147483646;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit57";
	rename -uid "039F6A8A-42E1-C232-C4DD-33AB6A0A678E";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483330 -2147483521;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit58";
	rename -uid "17B16AED-4D05-D7F0-BCFB-D6935AEA08C8";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483646 -2147483321;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit59";
	rename -uid "EA8F0FDA-42EC-9334-1FE0-438FBD24304C";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483321 -2147483339;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplitRing -n "polySplitRing10";
	rename -uid "2F25CBAA-4941-F221-3418-71835F6102E8";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 23 "e[54:55]" "e[57]" "e[59]" "e[61]" "e[63]" "e[65]" "e[67]" "e[75:76]" "e[81]" "e[84]" "e[103]" "e[148]" "e[180]" "e[203]" "e[219]" "e[242]" "e[258]" "e[275]" "e[283]" "e[291]" "e[299]" "e[470:472]" "e[486]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".wt" 0.35718047618865967;
	setAttr ".re" 258;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplit -n "polySplit60";
	rename -uid "14490A74-480D-EA79-64BD-9AA5A6F046E0";
	setAttr ".v[0]" -type "float3"  -0.40646949 0.5 -0.50378221;
	setAttr -s 7 ".e[0:6]"  0 0.434394 0.509013 0.61512297 2 0.618276
		 0;
	setAttr -s 7 ".d[0:6]"  -2147483340 -2147483645 -2147483431 -2147483392 0 -2147483643 
		-2147483640;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode deleteComponent -n "deleteComponent18";
	rename -uid "A79416D5-41F8-1AE1-D839-FBA7BBDE366D";
	setAttr ".dc" -type "componentList" 1 "e[573:574]";
createNode polyConnectComponents -n "polyConnectComponents1";
	rename -uid "55D2E075-446D-3FE3-62E7-688400F799C7";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "vtx[273:274]";
createNode polyTweak -n "polyTweak35";
	rename -uid "139ACA49-408B-FE58-1D9E-EF8E54E64C17";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk[271:274]" -type "float3"  -0.43650389 0 0 -1.11231899
		 0 0 -2.073344707 0 0 -2.10190344 0 0;
createNode polySplit -n "polySplit61";
	rename -uid "189A8F6A-400B-99B6-1393-CF889F12E35B";
	setAttr -s 5 ".e[0:4]"  0 0.60584402 0.60548103 0.60303199 1;
	setAttr -s 5 ".d[0:4]"  -2147483643 -2147483074 -2147483393 -2147483134 -2147483391;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweak -n "polyTweak36";
	rename -uid "CA3356FE-40F5-09B5-887B-65967FB2B496";
	setAttr ".uopa" yes;
	setAttr -s 3 ".tk[275:277]" -type "float3"  -2.8610229e-06 0 -2.613554
		 -2.8610229e-06 0 -2.62013817 -2.8610229e-06 0 -2.66453743;
createNode deleteComponent -n "deleteComponent19";
	rename -uid "3B238B6E-481B-882A-A153-FAAC64D7445A";
	setAttr ".dc" -type "componentList" 3 "f[112]" "f[297]" "f[301:302]";
createNode deleteComponent -n "deleteComponent20";
	rename -uid "B2214A77-441F-4D76-E272-F29DF4BF8EA2";
	setAttr ".dc" -type "componentList" 4 "f[122]" "f[127]" "f[171]" "f[179]";
createNode polyBridgeEdge -n "polyBridgeEdge4";
	rename -uid "C46B6448-445E-7E62-55B5-579AD26DF15B";
	setAttr ".ics" -type "componentList" 15 "e[76]" "e[218]" "e[293]" "e[320]" "e[355]" "e[408]" "e[421]" "e[507]" "e[549]" "e[551]" "e[558]" "e[560]" "e[564]" "e[566]" "e[571:572]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 263;
	setAttr ".sv2" 275;
	setAttr ".d" 1;
	setAttr ".sd" 1;
	setAttr ".td" 1;
createNode polySplitRing -n "polySplitRing11";
	rename -uid "7BA5166C-4407-C911-D2D3-D9905FB4C364";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 26 "e[20:22]" "e[41]" "e[56]" "e[95]" "e[119]" "e[140]" "e[172]" "e[190:191]" "e[193]" "e[195]" "e[197]" "e[199:200]" "e[202]" "e[204]" "e[206]" "e[213]" "e[225]" "e[322]" "e[324]" "e[375]" "e[377]" "e[381]" "e[384]" "e[529]" "e[557]" "e[563]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".wt" 0.68832290172576904;
	setAttr ".dr" no;
	setAttr ".re" 557;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak37";
	rename -uid "4D12A9DE-497C-CA1C-13D2-CBA7918BB4FA";
	setAttr ".uopa" yes;
	setAttr -s 30 ".tk[276:305]" -type "float3"  4.7788582e-16 0 -12.40927982
		 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982
		 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982
		 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982 4.7788582e-16
		 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982
		 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982
		 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982 0 0 -12.40927982;
createNode polySplit -n "polySplit62";
	rename -uid "EE5D9A5E-4892-7D5A-171C-8FA1825D3CAE";
	setAttr -s 7 ".e[0:6]"  0.120505 0.121857 0.12666 0.14370801 0.85451102
		 0.155696 0;
	setAttr -s 7 ".d[0:6]"  -2147483142 -2147483075 -2147483143 -2147483092 -2147483007 -2147483094 
		-2147483096;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyDelEdge -n "polyDelEdge6";
	rename -uid "87977634-4D63-4F84-9793-E0841BFFD5E7";
	setAttr ".ics" -type "componentList" 1 "e[643]";
	setAttr ".cv" yes;
createNode polyTweak -n "polyTweak38";
	rename -uid "1B5F1D45-4789-96B5-3B99-809A0E8F49C8";
	setAttr ".uopa" yes;
	setAttr -s 6 ".tk[306:311]" -type "float3"  -0.88735765 0 0 -0.93798119
		 0 0 -1.11783099 0 0 -1.75619042 0 0 -1.82287848 0 0 -2.20507908 0 0;
createNode polyDelEdge -n "polyDelEdge7";
	rename -uid "16880BA6-4F64-31E2-53D3-BD8AAC4E1AA1";
	setAttr ".ics" -type "componentList" 1 "e[573]";
	setAttr ".cv" yes;
createNode polySplit -n "polySplit63";
	rename -uid "1349633C-40A8-EC79-9774-E58CFAE9503A";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483079 -2147483142;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit64";
	rename -uid "5BBEFBC4-4FC8-F854-D4C5-02975314FA00";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483142 -2147483140;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyDelEdge -n "polyDelEdge8";
	rename -uid "1220477E-446F-8C8C-5D34-79B2CE895B87";
	setAttr ".ics" -type "componentList" 1 "e[499]";
	setAttr ".cv" yes;
createNode polyExtrudeFace -n "polyExtrudeFace6";
	rename -uid "E6C7A07A-4A77-6F62-8738-BE890C656E79";
	setAttr ".ics" -type "componentList" 7 "f[2]" "f[21]" "f[111]" "f[292:293]" "f[302:304]" "f[332:334]" "f[337]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.5937964 10.060561 -2.8091259 ;
	setAttr ".rs" 63811;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -3.4570822248558186 10.060561243375139 -4.3520488755980953 ;
	setAttr ".cbx" -type "double3" 0.2694894144593401 10.060561243375139 -1.2662032870849145 ;
createNode polyExtrudeFace -n "polyExtrudeFace7";
	rename -uid "F4A501DE-4D61-F927-4332-B490A0054470";
	setAttr ".ics" -type "componentList" 7 "f[2]" "f[21]" "f[111]" "f[292:293]" "f[302:304]" "f[332:334]" "f[337]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.5937964 12.11813 -2.8091259 ;
	setAttr ".rs" 55319;
	setAttr ".lt" -type "double3" -1.7053025658242404e-15 2.0722406267065923e-15 0.25740218835894957 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -3.4570822248558186 12.118129069320792 -4.3520488755980953 ;
	setAttr ".cbx" -type "double3" 0.2694894144593401 12.118129897405865 -1.2662032870849145 ;
createNode polyTweak -n "polyTweak39";
	rename -uid "7EE5C3A5-42EE-A809-3100-619BA05D7C05";
	setAttr ".uopa" yes;
	setAttr -s 44 ".tk";
	setAttr ".tk[9]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[31]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[112]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[113]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[133]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[242]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[243]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[268]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[270]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[271]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[272]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[273]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[274]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[275]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[276]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[277]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[278]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[279]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[306]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[307]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[308]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[309]" -type "float3" 0 -1.9073486e-06 0 ;
	setAttr ".tk[311]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[312]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[313]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[314]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[315]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[316]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[317]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[318]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[319]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[320]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[321]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[322]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[323]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[324]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[325]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[326]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[327]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[328]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[329]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[330]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[331]" -type "float3" 0 18.956985 0 ;
	setAttr ".tk[332]" -type "float3" 0 18.956985 0 ;
createNode deleteComponent -n "deleteComponent21";
	rename -uid "C9559FB9-4E12-09C7-D206-2B8315011838";
	setAttr ".dc" -type "componentList" 8 "f[362]" "f[364]" "f[366]" "f[369]" "f[371]" "f[373]" "f[377]" "f[381]";
createNode polyCloseBorder -n "polyCloseBorder2";
	rename -uid "F6F49817-488E-0EBA-4760-CCAA3C7F5F74";
	setAttr ".ics" -type "componentList" 8 "e[646]" "e[653]" "e[656]" "e[659]" "e[665]" "e[668]" "e[675]" "e[682]";
createNode polySplit -n "polySplit65";
	rename -uid "BE8E0D16-48E8-A5F8-BFCC-FAA39F44B19C";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483002 -2147482983;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit66";
	rename -uid "B8577B33-40E0-4F6C-E1FD-DF82B9C25BD1";
	setAttr -s 3 ".e[0:2]"  1 0.213081 1;
	setAttr -s 3 ".d[0:2]"  -2147482995 -2147482916 -2147482973;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyCloseBorder -n "polyCloseBorder3";
	rename -uid "60164022-4266-23DD-25AB-F086ADEF2696";
	setAttr ".ics" -type "componentList" 8 "e[689]" "e[697]" "e[701]" "e[704]" "e[709]" "e[714]" "e[721]" "e[730]";
createNode polySplit -n "polySplit67";
	rename -uid "98BA21FA-4903-952B-C7A2-86A065A6539D";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147482959 -2147482939;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit68";
	rename -uid "47C3A48E-4213-1350-E750-92B3FF9E2E34";
	setAttr -s 3 ".e[0:2]"  1 0.213081 1;
	setAttr -s 3 ".d[0:2]"  -2147482951 -2147482912 -2147482927;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyDelEdge -n "polyDelEdge9";
	rename -uid "9FA5751B-489D-5FC8-3D06-0A857DD47598";
	setAttr ".ics" -type "componentList" 17 "e[56]" "e[58]" "e[68]" "e[70]" "e[474]" "e[567]" "e[571]" "e[644]" "e[648]" "e[661]" "e[664]" "e[692]" "e[694]" "e[706]" "e[710]" "e[732:733]" "e[736:737]";
	setAttr ".cv" yes;
createNode polyConnectComponents -n "polyConnectComponents2";
	rename -uid "95944BB6-491C-02E5-B875-0089B624BE70";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[30]" "vtx[266]";
createNode polyDelEdge -n "polyDelEdge10";
	rename -uid "D152FF41-470B-1F7F-6E5C-0D92DD07C5BF";
	setAttr ".ics" -type "componentList" 28 "e[187]" "e[189]" "e[191]" "e[194]" "e[196]" "e[198]" "e[201]" "e[203]" "e[205]" "e[207]" "e[211]" "e[213]" "e[215]" "e[217:218]" "e[311]" "e[314]" "e[364]" "e[367]" "e[370]" "e[373]" "e[416:418]" "e[511]" "e[616]" "e[632]" "e[653]" "e[668:669]" "e[680]" "e[691:692]";
	setAttr ".cv" yes;
createNode polyTweak -n "polyTweak40";
	rename -uid "DDAA38AA-427C-0C30-8C02-F6A3F889193C";
	setAttr ".uopa" yes;
	setAttr -s 5 ".tk[265:269]" -type "float3"  0 0 2.26646662 0 0 2.26646662
		 0 0 2.26646662 0 0 2.26646662 0 0 2.26646662;
createNode polySplit -n "polySplit69";
	rename -uid "888755DC-4F01-421B-2808-1C979CB48CAD";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483465 -2147483428;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyConnectComponents -n "polyConnectComponents3";
	rename -uid "6F649677-4363-3ACD-8EF7-71AD1FDBC63F";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[95]" "vtx[265]";
createNode polyDelEdge -n "polyDelEdge11";
	rename -uid "A9E337FE-4959-0A4C-3061-AE965E74A149";
	setAttr ".ics" -type "componentList" 23 "e[194]" "e[196:197]" "e[200]" "e[202:203]" "e[206]" "e[208]" "e[210:211]" "e[215]" "e[217]" "e[219]" "e[221:222]" "e[280]" "e[282]" "e[286:287]" "e[291:292]" "e[364:366]" "e[462]" "e[565]" "e[583]" "e[599]" "e[612:613]" "e[629:630]" "e[637]";
	setAttr ".cv" yes;
createNode polyConnectComponents -n "polyConnectComponents4";
	rename -uid "314E1074-4873-7FC1-B03F-6797E5DCC18C";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[56]" "vtx[96]";
createNode polyConnectComponents -n "polyConnectComponents5";
	rename -uid "C1166EEF-4CFD-AAB8-F9A6-5383AB7F7FE3";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[60]" "vtx[97]";
createNode polyDelEdge -n "polyDelEdge12";
	rename -uid "F4CA2601-402F-538B-5D92-3F93742B8E05";
	setAttr ".ics" -type "componentList" 3 "e[552]" "e[556]" "e[567]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge13";
	rename -uid "10D85E86-4411-B85D-CED8-1DB701652444";
	setAttr ".ics" -type "componentList" 7 "e[523]" "e[531]" "e[534]" "e[539:540]" "e[542]" "e[546]" "e[548]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge14";
	rename -uid "B44B0876-42D5-1F06-7388-56B154D7702B";
	setAttr ".ics" -type "componentList" 4 "e[447:448]" "e[450]" "e[534]" "e[539:540]";
	setAttr ".cv" yes;
createNode polyConnectComponents -n "polyConnectComponents6";
	rename -uid "24C8C57D-4ABE-630A-3F05-9998A5B40CD0";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[6]" "vtx[131]";
createNode polyTweakUV -n "polyTweakUV9";
	rename -uid "D7F5DE56-48D0-0622-B6BB-AB8EB60C9F6B";
	setAttr ".uopa" yes;
	setAttr -s 2 ".uvtk";
	setAttr ".uvtk[138]" -type "float2" -0.010049305 0.018540863 ;
	setAttr ".uvtk[314]" -type "float2" -0.008459013 0.024481609 ;
createNode polyMergeVert -n "polyMergeVert11";
	rename -uid "CDF2E6FE-494D-CB62-7085-D58C4D059988";
	setAttr ".ics" -type "componentList" 2 "vtx[9]" "vtx[215]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak41";
	rename -uid "0D6C4FA1-4A2E-5BD2-E7FE-668714AB265C";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[9]" -type "float3" 0 -3.8146973e-06 3.8146973e-06 ;
	setAttr ".tk[215]" -type "float3" -3.4977989 -3.8146973e-06 3.8146973e-06 ;
createNode polyDelEdge -n "polyDelEdge15";
	rename -uid "EBE1F1FC-4E04-9AFD-3FE6-3AA96BA94E2E";
	setAttr ".ics" -type "componentList" 4 "e[397]" "e[439:440]" "e[529:530]" "e[538]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge16";
	rename -uid "F29D8EFD-43F5-1574-A8BC-9F86790235EF";
	setAttr ".ics" -type "componentList" 15 "e[36]" "e[38]" "e[42]" "e[45]" "e[47]" "e[58]" "e[60]" "e[185:186]" "e[193]" "e[201]" "e[207]" "e[215]" "e[357:360]" "e[367]" "e[474]";
	setAttr ".cv" yes;
createNode polySplit -n "polySplit70";
	rename -uid "09ECC470-4187-8661-C4F3-5B8278D7C3D8";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483626 -2147483614;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyConnectComponents -n "polyConnectComponents7";
	rename -uid "B4FEBF1C-4956-4A5A-FB9A-359C560B4188";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[21]" "vtx[23]";
createNode polyTweakUV -n "polyTweakUV10";
	rename -uid "2DF23171-4C19-CF20-9165-25894607CC89";
	setAttr ".uopa" yes;
	setAttr -s 3 ".uvtk";
	setAttr ".uvtk[29]" -type "float2" 0 3.681922e-08 ;
	setAttr ".uvtk[146]" -type "float2" -0.10604495 -1.2693056e-07 ;
	setAttr ".uvtk[254]" -type "float2" 0 -2.4424907e-15 ;
createNode polyMergeVert -n "polyMergeVert12";
	rename -uid "4BB9903E-429E-A4D6-1A90-F4B1D37EE872";
	setAttr ".ics" -type "componentList" 2 "vtx[35]" "vtx[171]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak42";
	rename -uid "E35D0B78-4224-2DE4-DA2F-99B7DE122BA8";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[35]" -type "float3" 0 0 3.8146973e-06 ;
	setAttr ".tk[171]" -type "float3" 9.0568161 0 -3.8146973e-06 ;
createNode polyTweakUV -n "polyTweakUV11";
	rename -uid "9F84DB3F-451D-3B5B-0838-4B9DE63865DD";
	setAttr ".uopa" yes;
	setAttr -s 3 ".uvtk";
	setAttr ".uvtk[122]" -type "float2" 1.2213744e-07 -1.1898297e-07 ;
	setAttr ".uvtk[189]" -type "float2" 0 1.5768526e-08 ;
	setAttr ".uvtk[255]" -type "float2" 0 5.9604652e-08 ;
createNode polyMergeVert -n "polyMergeVert13";
	rename -uid "C3667926-493E-C492-5E84-868B15AEB2CE";
	setAttr ".ics" -type "componentList" 2 "vtx[164]" "vtx[172]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak43";
	rename -uid "7FAFE224-45FB-C0DC-5174-019D97E94DD9";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[164]" -type "float3" 0 0 3.8146973e-06 ;
	setAttr ".tk[172]" -type "float3" 9.0568161 0 3.8146973e-06 ;
createNode polyDelEdge -n "polyDelEdge17";
	rename -uid "9637DEA8-4E2D-3B5C-F41A-C5A8B752D595";
	setAttr ".ics" -type "componentList" 5 "e[7]" "e[34]" "e[83:84]" "e[169]" "e[454]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge18";
	rename -uid "BC5CF76D-476E-3A77-C6B1-6EBFCD67C501";
	setAttr ".ics" -type "componentList" 2 "e[483]" "e[485]";
	setAttr ".cv" yes;
createNode polyConnectComponents -n "polyConnectComponents8";
	rename -uid "F261F715-40D8-9249-ECA7-2AA1AB2EE7EA";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[82]" "vtx[216]";
createNode polySplit -n "polySplit71";
	rename -uid "7656154D-427A-EB51-AEEE-AEADF4757E60";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483568 -2147483492;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweakUV -n "polyTweakUV12";
	rename -uid "06345E00-451A-8B90-7437-55A6194D65DE";
	setAttr ".uopa" yes;
	setAttr -s 2 ".uvtk";
	setAttr ".uvtk[83]" -type "float2" -0.011326883 0.0019971051 ;
	setAttr ".uvtk[305]" -type "float2" 0.020510759 0.014201164 ;
createNode polyMergeVert -n "polyMergeVert14";
	rename -uid "5C43DDEA-4C77-E5ED-62F0-8B9A18D8E4D1";
	setAttr ".ics" -type "componentList" 2 "vtx[82]" "vtx[215]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak44";
	rename -uid "953DBED7-410E-2F4F-32E1-4AA6FB126803";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[82]" -type "float3" 0 -9.5367432e-07 9.5367432e-07 ;
	setAttr ".tk[215]" -type "float3" 0 -9.5367432e-07 -5.2481394 ;
createNode polyTweakUV -n "polyTweakUV13";
	rename -uid "83EF7B46-4074-27D6-253B-F49E1E026D98";
	setAttr ".uopa" yes;
	setAttr -s 2 ".uvtk";
	setAttr ".uvtk[84]" -type "float2" -0.0067139268 -0.011379895 ;
	setAttr ".uvtk[304]" -type "float2" 0.021148998 0.002833935 ;
createNode polyMergeVert -n "polyMergeVert15";
	rename -uid "942D9B10-4632-1F5F-FF8A-1A97371341C3";
	setAttr ".ics" -type "componentList" 2 "vtx[83]" "vtx[214]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak45";
	rename -uid "8F836292-426E-1802-F3CC-16B595CE35C7";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[83]" -type "float3" 0 -9.5367432e-07 9.5367432e-07 ;
	setAttr ".tk[214]" -type "float3" 0 -9.5367432e-07 -5.2481394 ;
createNode polyDelEdge -n "polyDelEdge19";
	rename -uid "413E8B24-4021-AA99-4BDE-84B2AB7511E7";
	setAttr ".ics" -type "componentList" 19 "e[404]" "e[406]" "e[408]" "e[410]" "e[412]" "e[414]" "e[416]" "e[418]" "e[420]" "e[422]" "e[424]" "e[426]" "e[428]" "e[430]" "e[432]" "e[434]" "e[436]" "e[438]" "e[476]";
	setAttr ".cv" yes;
createNode polySplit -n "polySplit72";
	rename -uid "F9592D1C-4824-091E-B817-37B4BC69A7A5";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483443 -2147483631;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyConnectComponents -n "polyConnectComponents9";
	rename -uid "39820AED-4DF8-5049-49C3-21A20412DAD7";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[49]" "vtx[83]";
createNode polyDelEdge -n "polyDelEdge20";
	rename -uid "329128B2-49B6-1732-A176-7FBFCD5212B2";
	setAttr ".ics" -type "componentList" 18 "e[343]" "e[345]" "e[347]" "e[349]" "e[351]" "e[353]" "e[355]" "e[357]" "e[359]" "e[361]" "e[363]" "e[365]" "e[367]" "e[369]" "e[371]" "e[373]" "e[375]" "e[417]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge21";
	rename -uid "4E58C43E-44E6-9767-0524-35990680F63C";
	setAttr ".ics" -type "componentList" 2 "e[347]" "e[381:382]";
	setAttr ".cv" yes;
createNode polyConnectComponents -n "polyConnectComponents10";
	rename -uid "62D0EF8E-4804-1080-1207-C69F5AD173B9";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[129]" "vtx[171]";
createNode polyConnectComponents -n "polyConnectComponents11";
	rename -uid "4CE95D64-498B-954B-3E0C-77A8AD9093C2";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[7]" "vtx[182]";
createNode polySplit -n "polySplit73";
	rename -uid "6A997DA2-4D48-F527-5CB0-D9820E85E078";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483615 -2147483299;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyDelEdge -n "polyDelEdge22";
	rename -uid "B7F2FFFC-4A04-0506-0797-45979EB4E004";
	setAttr ".ics" -type "componentList" 4 "e[35:38]" "e[151]" "e[162]" "e[295:298]";
	setAttr ".cv" yes;
createNode polyConnectComponents -n "polyConnectComponents12";
	rename -uid "ED8C607F-4B9E-F5A6-908F-CFA664581C0E";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[18]" "vtx[23]";
createNode polyTweakUV -n "polyTweakUV14";
	rename -uid "DBDFFC0C-4F79-CC60-0ACB-3CA262736018";
	setAttr ".uopa" yes;
	setAttr -s 3 ".uvtk";
	setAttr ".uvtk[22]" -type "float2" 0.10604502 -1.3535892e-07 ;
	setAttr ".uvtk[166]" -type "float2" 0 -2.2785425e-08 ;
	setAttr ".uvtk[234]" -type "float2" 0 -3.1537052e-08 ;
createNode polyMergeVert -n "polyMergeVert16";
	rename -uid "10F92ED7-4C50-6337-A07F-72996B44BF44";
	setAttr ".ics" -type "componentList" 2 "vtx[30]" "vtx[158]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak46";
	rename -uid "F7727C3E-4321-A725-8B3F-CDA597DAF820";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[30]" -type "float3" 0 0 3.8146973e-06 ;
	setAttr ".tk[158]" -type "float3" -9.0568199 0 3.8146973e-06 ;
createNode polyTweakUV -n "polyTweakUV15";
	rename -uid "49D2C5E7-4CFD-5671-9F71-0893F5CF6CE6";
	setAttr ".uopa" yes;
	setAttr -s 3 ".uvtk";
	setAttr ".uvtk[138]" -type "float2" -1.221365e-07 -1.4133201e-07 ;
	setAttr ".uvtk[170]" -type "float2" 0 -1.5768526e-08 ;
	setAttr ".uvtk[234]" -type "float2" 0 4.5570857e-08 ;
createNode polyMergeVert -n "polyMergeVert17";
	rename -uid "79CA73A1-4CBA-F32C-B4CA-4D98BBAE5A0E";
	setAttr ".ics" -type "componentList" 2 "vtx[147]" "vtx[158]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak47";
	rename -uid "0E78EB26-4D8A-3D37-E055-B3B2B9A36B33";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[147]" -type "float3" 0 0 3.8146973e-06 ;
	setAttr ".tk[158]" -type "float3" -9.0568047 0 3.8146973e-06 ;
createNode polySplit -n "polySplit74";
	rename -uid "CFF605B2-4C36-D7AE-5B4A-5099D0F33517";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483363 -2147483330;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyDelEdge -n "polyDelEdge23";
	rename -uid "4440DBDC-4ED0-7758-1A9F-C2BE24803646";
	setAttr ".ics" -type "componentList" 19 "e[73]" "e[75]" "e[77]" "e[79]" "e[81]" "e[83]" "e[86]" "e[88]" "e[90]" "e[93]" "e[95]" "e[97]" "e[99:100]" "e[140]" "e[148]" "e[158]" "e[308]" "e[339]" "e[346]";
	setAttr ".cv" yes;
createNode polyConnectComponents -n "polyConnectComponents13";
	rename -uid "8555DD14-4B55-8C54-6FB5-C09E3932FB32";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[43]" "vtx[62]";
createNode polyDelEdge -n "polyDelEdge24";
	rename -uid "5962B9D1-442F-6A17-E431-B1A0A335E88D";
	setAttr ".ics" -type "componentList" 18 "e[74]" "e[76]" "e[78]" "e[80]" "e[82:83]" "e[86]" "e[88]" "e[90]" "e[93]" "e[95]" "e[97]" "e[99:100]" "e[110]" "e[115]" "e[123]" "e[273]" "e[303]" "e[308]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge25";
	rename -uid "C727878A-4C9C-E6F9-96A1-978508C23FE5";
	setAttr ".ics" -type "componentList" 3 "e[273]" "e[275:276]" "e[306]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge26";
	rename -uid "2F886A77-4101-9ED1-42D6-BBAE36DE5385";
	setAttr ".ics" -type "componentList" 15 "e[37]" "e[39:40]" "e[43]" "e[45]" "e[47]" "e[50]" "e[52]" "e[54:55]" "e[79]" "e[81]" "e[85]" "e[87]" "e[208]" "e[236]" "e[265]";
	setAttr ".cv" yes;
createNode polyConnectComponents -n "polyConnectComponents14";
	rename -uid "AB974ED0-496B-32B0-5E33-95A0AFCDDD2A";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[31]" "vtx[67]";
createNode polySplit -n "polySplit75";
	rename -uid "B383EEA5-4B30-72B7-C022-0C95D02CA666";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483640 -2147483632;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweakUV -n "polyTweakUV16";
	rename -uid "CC0F964E-4776-FAE2-0502-C48242EDE474";
	setAttr ".uopa" yes;
	setAttr -s 2 ".uvtk";
	setAttr ".uvtk[4]" -type "float2" 0.049908403 -0.0030198356 ;
	setAttr ".uvtk[14]" -type "float2" -0.0092375334 -0.017433112 ;
createNode polyMergeVert -n "polyMergeVert18";
	rename -uid "2D95A1D9-44E5-450A-84E3-56827407D751";
	setAttr ".ics" -type "componentList" 2 "vtx[13]" "vtx[22]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak48";
	rename -uid "49D8BB4D-4C6E-F33B-5616-8F8591872073";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[13]" -type "float3" 9.0568047 0 3.8146973e-06 ;
	setAttr ".tk[22]" -type "float3" 0 0 3.8146973e-06 ;
createNode polyTweakUV -n "polyTweakUV17";
	rename -uid "0F402D02-4CF7-6DAA-4D04-7FB9C2939A15";
	setAttr ".uopa" yes;
	setAttr -s 2 ".uvtk";
	setAttr ".uvtk[6]" -type "float2" 0.055177353 0.0065888865 ;
	setAttr ".uvtk[14]" -type "float2" -0.0091347201 0.017410452 ;
createNode polyMergeVert -n "polyMergeVert19";
	rename -uid "2A6C2DE9-46D4-BF4C-41D2-63854B5049BF";
	setAttr ".ics" -type "componentList" 2 "vtx[15]" "vtx[22]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak49";
	rename -uid "2945E86C-45CE-83E3-ACD9-E9B00BACC2C5";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[15]" -type "float3" 9.0568047 0 3.8146973e-06 ;
	setAttr ".tk[22]" -type "float3" 0 0 3.8146973e-06 ;
createNode polyTweakUV -n "polyTweakUV18";
	rename -uid "74C1A464-4F61-182D-66AE-63AE9B71CAE2";
	setAttr ".uopa" yes;
	setAttr -s 2 ".uvtk";
	setAttr ".uvtk[7]" -type "float2" -0.053926434 0.02436799 ;
	setAttr ".uvtk[13]" -type "float2" 0.010372608 0.017249592 ;
createNode polyMergeVert -n "polyMergeVert20";
	rename -uid "892C80E4-4A34-B1EC-2374-5D8E686BE7C8";
	setAttr ".ics" -type "componentList" 2 "vtx[16]" "vtx[21]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak50";
	rename -uid "D509A71C-4519-F5C0-B6F4-55A8740AD1CE";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[16]" -type "float3" -9.0568161 0 3.8146973e-06 ;
	setAttr ".tk[21]" -type "float3" 0 0 3.8146973e-06 ;
createNode polyDelEdge -n "polyDelEdge27";
	rename -uid "3463DBB4-4506-DC51-C5F7-73898CE2F83E";
	setAttr ".ics" -type "componentList" 2 "e[16]" "e[235]";
	setAttr ".cv" yes;
createNode polyTweakUV -n "polyTweakUV19";
	rename -uid "40AA9FBD-44C2-6499-2386-27A78EBE05AA";
	setAttr ".uopa" yes;
	setAttr -s 2 ".uvtk";
	setAttr ".uvtk[1]" -type "float2" -0.020466782 -0.020714447 ;
	setAttr ".uvtk[46]" -type "float2" 0.026366713 -0.0017041079 ;
createNode polyMergeVert -n "polyMergeVert21";
	rename -uid "67CF00E6-414A-29A8-E11E-B99A39186961";
	setAttr ".ics" -type "componentList" 1 "vtx[7:8]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak51";
	rename -uid "5FBA3122-4294-0254-D885-5289E6E9AF47";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk[7:8]" -type "float3"  3.49798203 -3.8146973e-06
		 0 0 -3.8146973e-06 0;
createNode polyTweakUV -n "polyTweakUV20";
	rename -uid "D6EE64E5-4D2B-1D4B-BA16-C5994010E807";
	setAttr ".uopa" yes;
	setAttr -s 3 ".uvtk";
	setAttr ".uvtk[2]" -type "float2" 0.025737807 0.011416742 ;
	setAttr ".uvtk[3]" -type "float2" -0.041413561 0.010436724 ;
	setAttr ".uvtk[10]" -type "float2" -0.0016661857 -0.00021932073 ;
createNode polyMergeVert -n "polyMergeVert22";
	rename -uid "43D1A97C-4826-061C-5508-2884C954AA91";
	setAttr ".ics" -type "componentList" 1 "vtx[9:10]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak52";
	rename -uid "6FE6F832-49C6-C95E-4300-09902C64C2FB";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk[9:10]" -type "float3"  3.49798203 -3.8146973e-06
		 3.8146973e-06 0 -3.8146973e-06 3.8146973e-06;
createNode polyDelEdge -n "polyDelEdge28";
	rename -uid "29BA350C-458D-B280-1256-74B177DDD307";
	setAttr ".ics" -type "componentList" 2 "e[69]" "e[195]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge29";
	rename -uid "5B634299-469A-3B27-6A43-9581CC3DFF90";
	setAttr ".ics" -type "componentList" 1 "e[70]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge30";
	rename -uid "41EBEF93-407E-723F-577B-26B97EF8943A";
	setAttr ".ics" -type "componentList" 2 "e[68:69]" "e[169]";
	setAttr ".cv" yes;
createNode polyConnectComponents -n "polyConnectComponents15";
	rename -uid "FFDD9F75-4703-347E-28C0-2587830E0FF9";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[6]" "vtx[67]";
createNode polySplit -n "polySplit76";
	rename -uid "9663FD71-48DF-6CA7-EAAE-2FBDBCE21279";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483639 -2147483544;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyDelEdge -n "polyDelEdge31";
	rename -uid "BBB50169-425B-1EF1-9804-0A923A81DA2B";
	setAttr ".ics" -type "componentList" 9 "e[6]" "e[64]" "e[66:67]" "e[166]" "e[174]" "e[176]" "e[184]" "e[186]" "e[260]";
	setAttr ".cv" yes;
createNode polyConnectComponents -n "polyConnectComponents16";
	rename -uid "84D84E9F-4152-F841-5AA4-B0BE083F50D8";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[1]" "vtx[59]";
createNode polyConnectComponents -n "polyConnectComponents17";
	rename -uid "D5A6803B-4C31-7001-1729-2BB52F53D6AF";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[58]" "vtx[70]";
createNode polyConnectComponents -n "polyConnectComponents18";
	rename -uid "38C884A3-4EB7-39EB-E398-C3ACC3BA4AAE";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[60]" "vtx[71]";
createNode polyDelEdge -n "polyDelEdge32";
	rename -uid "77A77FAB-4A45-9332-9CD7-278E4272BDA1";
	setAttr ".ics" -type "componentList" 2 "e[4]" "e[41]";
	setAttr ".cv" yes;
createNode polyConnectComponents -n "polyConnectComponents19";
	rename -uid "352572C0-41CB-20D9-B49A-90AA8CD9F6BB";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[23]" "vtx[58]";
createNode polyDelEdge -n "polyDelEdge33";
	rename -uid "1C91EB64-4EAA-5706-CF00-919F9E04FCD9";
	setAttr ".ics" -type "componentList" 2 "e[3]" "e[15]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge34";
	rename -uid "14FB29F2-436D-0566-859B-469E1DA1CD35";
	setAttr ".ics" -type "componentList" 2 "e[2]" "e[36]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge35";
	rename -uid "97331E5C-4789-024B-594B-349DACA78FBD";
	setAttr ".ics" -type "componentList" 6 "e[0]" "e[2]" "e[48:49]" "e[150]" "e[158:159]" "e[166:167]";
	setAttr ".cv" yes;
createNode polySplit -n "polySplit77";
	rename -uid "0873EC88-439E-E290-0353-6BA1922147DC";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483587 -2147483598;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyConnectComponents -n "polyConnectComponents20";
	rename -uid "28448456-434F-38C8-96B8-79AD4B5FA856";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[39]" "vtx[66]";
createNode polyConnectComponents -n "polyConnectComponents21";
	rename -uid "8617B2AF-40EB-BF0F-92FF-02A96A2E0143";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[0]" "vtx[41]";
createNode polyDelEdge -n "polyDelEdge36";
	rename -uid "15B1EDED-4567-79FA-A26E-56A8062EEE9F";
	setAttr ".ics" -type "componentList" 5 "e[0]" "e[45:47]" "e[145]" "e[159:161]" "e[221]";
	setAttr ".cv" yes;
createNode polySplit -n "polySplit78";
	rename -uid "A531D2FC-45D1-763A-8C42-479902F723CD";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483598 -2147483584;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit79";
	rename -uid "A2FE5AA4-4489-ED66-8380-068AC3603708";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483598 -2147483582;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit80";
	rename -uid "974A4E47-4801-DD14-414C-63ADFE4809DA";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483599 -2147483606;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyDelEdge -n "polyDelEdge37";
	rename -uid "86FFB8B8-4A00-291F-D656-8BAA961A65AC";
	setAttr ".ics" -type "componentList" 15 "e[97]" "e[101]" "e[104]" "e[108]" "e[111]" "e[115]" "e[118]" "e[122]" "e[128:131]" "e[163]" "e[176]" "e[179]" "e[194]" "e[199]" "e[210]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge38";
	rename -uid "E65AE000-47FE-586F-F57D-9CBAEEABDCD5";
	setAttr ".ics" -type "componentList" 3 "e[141]" "e[143]" "e[145:146]";
	setAttr ".cv" yes;
createNode polyConnectComponents -n "polyConnectComponents22";
	rename -uid "F662D83B-441A-D4BB-2FEF-33AAF551EC8E";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "vtx[16:17]";
createNode polyDelEdge -n "polyDelEdge39";
	rename -uid "D72F101B-4F9D-61CC-C5DF-219F37E51862";
	setAttr ".ics" -type "componentList" 1 "e[116:119]";
	setAttr ".cv" yes;
createNode polyTweakUV -n "polyTweakUV21";
	rename -uid "075190BC-40D7-D771-8DED-B7955576A9DA";
	setAttr ".uopa" yes;
	setAttr -s 4 ".uvtk";
	setAttr ".uvtk[13]" -type "float2" 0.15076044 1.8252814e-08 ;
	setAttr ".uvtk[37]" -type "float2" -0.048711278 -7.0846028e-08 ;
	setAttr ".uvtk[72]" -type "float2" 0 1.4033795e-08 ;
	setAttr ".uvtk[73]" -type "float2" 0 -7.0168338e-09 ;
createNode polyMergeVert -n "polyMergeVert23";
	rename -uid "D3319786-4DDA-8553-1086-44BCD6A5900A";
	setAttr ".ics" -type "componentList" 2 "vtx[17]" "vtx[73]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak53";
	rename -uid "C993845B-4258-1303-3E45-0B8E35CE5AA3";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[17]" -type "float3" 0 -4.8321114 0 ;
	setAttr ".tk[73]" -type "float3" 0 0 3.8146973e-06 ;
createNode polyTweakUV -n "polyTweakUV22";
	rename -uid "AD363CD3-44E1-0446-A080-A19248342F52";
	setAttr ".uopa" yes;
	setAttr -s 5 ".uvtk";
	setAttr ".uvtk[12]" -type "float2" 0 -2.9802322e-08 ;
	setAttr ".uvtk[52]" -type "float2" -0.13532574 -0.053107865 ;
	setAttr ".uvtk[53]" -type "float2" 0.060678702 -0.036007367 ;
	setAttr ".uvtk[70]" -type "float2" 0 7.0168937e-09 ;
createNode polyMergeVert -n "polyMergeVert24";
	rename -uid "57A579F4-4972-522E-0D1F-DFB04BEC508F";
	setAttr ".ics" -type "componentList" 2 "vtx[16]" "vtx[69]";
	setAttr ".ix" -type "matrix" 7.4342347496015782 0 0 0 0 10.853876682068021 0 0 0 0 4.1928441602902531 0
		 0 463.36229023411272 -210.19754928557842 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak54";
	rename -uid "9CAAA637-45EB-8F17-9141-2F899A2448BA";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[16]" -type "float3" 0 -4.8321114 0 ;
	setAttr ".tk[69]" -type "float3" 0 0 3.8146973e-06 ;
createNode polySplit -n "polySplit81";
	rename -uid "187DB3FC-4253-0BE0-650D-D4B3EF203CC3";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483555 -2147483556;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit82";
	rename -uid "7729F818-4FA4-0004-F614-5A86621997D5";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483559 -2147483558;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyConnectComponents -n "polyConnectComponents23";
	rename -uid "557E67A6-4717-152E-9710-7AAF3A26734D";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[16]" "vtx[29]";
createNode polySplit -n "polySplit83";
	rename -uid "6D8D951D-4BDB-6939-C788-87A733CDC65E";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483614 -2147483548;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyDelEdge -n "polyDelEdge40";
	rename -uid "F0D8D82F-4DCA-DEC5-D9F6-F2BF7F7389AE";
	setAttr ".ics" -type "componentList" 6 "e[58:59]" "e[65:66]" "e[72:73]" "e[79:80]" "e[102:105]" "e[132]";
	setAttr ".cv" yes;
createNode polyConnectComponents -n "polyConnectComponents24";
	rename -uid "0865A8BF-4D24-637C-7B92-B1B4D7EE4F3D";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[30]" "vtx[48]";
createNode polyConnectComponents -n "polyConnectComponents25";
	rename -uid "036D230A-4AC6-466C-824E-FC8649B5908A";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[31]" "vtx[47]";
createNode polyDelEdge -n "polyDelEdge41";
	rename -uid "C60D5A34-4E3D-1BB8-A8E0-35AB57AD85EF";
	setAttr ".ics" -type "componentList" 1 "e[145]";
	setAttr ".cv" yes;
createNode polyConnectComponents -n "polyConnectComponents26";
	rename -uid "B5BBB658-40C6-736E-7ED0-D1AB6789BD67";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "vtx[11]" "vtx[70]";
createNode polyCube -n "polyCube8";
	rename -uid "3FD4EA1D-45E8-029D-0B68-478B6989BED3";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".w" 1;
	setAttr ".h" 1;
	setAttr ".d" 1;
	setAttr ".sd" 4;
	setAttr ".cuv" 4;
createNode polyDelEdge -n "polyDelEdge42";
	rename -uid "825939DE-419E-D460-B6F9-A694B823F967";
	setAttr ".ics" -type "componentList" 4 "e[4]" "e[7]" "e[30]" "e[33]";
	setAttr ".cv" yes;
createNode polySplitRing -n "polySplitRing12";
	rename -uid "CB7F0BCE-461B-DFFE-A3DE-6AA3A433F99B";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[0:7]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".wt" 0.45066216588020325;
	setAttr ".re" 2;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak55";
	rename -uid "B00DAD50-4186-1B44-36D1-F28DFF968BB5";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk";
	setAttr ".tk[4]" -type "float3" 0 0 -3.6147099 ;
	setAttr ".tk[5]" -type "float3" 0 0 -3.6147099 ;
	setAttr ".tk[6]" -type "float3" 0 0 -3.6147099 ;
	setAttr ".tk[7]" -type "float3" 0 0 -3.6147099 ;
	setAttr ".tk[12]" -type "float3" 0 0 -3.6147099 ;
	setAttr ".tk[13]" -type "float3" 0 0 -3.6147099 ;
	setAttr ".tk[14]" -type "float3" 0 0 -3.6147099 ;
	setAttr ".tk[15]" -type "float3" 0 0 -3.6147099 ;
createNode polyTweak -n "polyTweak56";
	rename -uid "10FCC97D-4FC1-304A-EC70-F8B6CECE3F72";
	setAttr ".uopa" yes;
	setAttr -s 16 ".tk[16:31]" -type "float3"  -46.52103806 0 0 -46.52103806
		 0 0 -46.52103806 0 0 -46.52103806 0 0 -46.52103806 0 0 -46.52103806 0 0 -46.52103806
		 0 0 -46.52103806 0 0 -26.30998039 0 0 -26.30998039 0 0 -26.30998039 0 0 -26.30998039
		 0 0 -26.30998039 0 0 -26.30998039 0 0 -26.30998039 0 0 -26.30998039 0 0;
createNode deleteComponent -n "deleteComponent22";
	rename -uid "86034276-4A8B-6B52-383E-92B45E64B7BD";
	setAttr ".dc" -type "componentList" 2 "f[22]" "f[26]";
createNode polyBridgeEdge -n "polyBridgeEdge5";
	rename -uid "DE45D146-42DB-3E28-A435-E99704A82137";
	setAttr ".ics" -type "componentList" 5 "e[30]" "e[38]" "e[44:46]" "e[51]" "e[53:54]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 17;
	setAttr ".sv2" 20;
	setAttr ".d" 1;
	setAttr ".sd" 1;
	setAttr ".td" 1;
createNode polyTweakUV -n "polyTweakUV23";
	rename -uid "130A4975-4159-CEAF-2384-C592FB7AF65F";
	setAttr ".uopa" yes;
	setAttr -s 4 ".uvtk";
	setAttr ".uvtk[7]" -type "float2" 1.4121497e-09 0.12393924 ;
	setAttr ".uvtk[9]" -type "float2" -3.2670933e-10 -1.1107331e-08 ;
	setAttr ".uvtk[21]" -type "float2" -2.3645798e-08 6.1264516e-10 ;
	setAttr ".uvtk[22]" -type "float2" 0.12393925 -1.4399071e-09 ;
createNode polyMergeVert -n "polyMergeVert25";
	rename -uid "58247167-4AC7-BD27-F864-03BD52F7B793";
	setAttr ".ics" -type "componentList" 2 "vtx[7]" "vtx[9]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak57";
	rename -uid "27722C17-49AF-6DB8-7773-5B9FA9B01160";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[7]" -type "float3" 0 0 -46.385288 ;
	setAttr ".tk[9]" -type "float3" 0 0 3.8146973e-06 ;
createNode polyTweakUV -n "polyTweakUV24";
	rename -uid "757DF51A-414C-96F4-4CAE-20BF832FAD12";
	setAttr ".uopa" yes;
	setAttr -s 4 ".uvtk";
	setAttr ".uvtk[10]" -type "float2" -3.267091e-10 -6.6285436e-05 ;
	setAttr ".uvtk[12]" -type "float2" 1.4121497e-09 -0.12393922 ;
	setAttr ".uvtk[17]" -type "float2" -3.9707011e-09 4.059769e-09 ;
	setAttr ".uvtk[18]" -type "float2" 0.12347589 1.146226e-09 ;
createNode polyMergeVert -n "polyMergeVert26";
	rename -uid "35FE8FA5-4EF9-2610-011A-30B4D95A42E6";
	setAttr ".ics" -type "componentList" 2 "vtx[10]" "vtx[12]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak58";
	rename -uid "ED0AA7DB-46FC-957C-5BCD-768B1ABF5D83";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[10]" -type "float3" 0 0 3.8146973e-06 ;
	setAttr ".tk[12]" -type "float3" 0 0 -46.385288 ;
createNode polyTweakUV -n "polyTweakUV25";
	rename -uid "7C543D1B-417C-1B9E-8D4A-8C957C05AE53";
	setAttr ".uopa" yes;
	setAttr -s 3 ".uvtk";
	setAttr ".uvtk[3]" -type "float2" 4.084193e-10 2.2928998e-10 ;
	setAttr ".uvtk[5]" -type "float2" -7.0955548e-09 -0.066641808 ;
	setAttr ".uvtk[19]" -type "float2" -0.068260446 4.1466737e-09 ;
createNode polyMergeVert -n "polyMergeVert27";
	rename -uid "D6CA158C-4637-CF9C-7712-138965A1D71E";
	setAttr ".ics" -type "componentList" 2 "vtx[3]" "vtx[5]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak59";
	rename -uid "28BFA31A-4951-4D20-8E6D-C69ACC3BE188";
	setAttr ".uopa" yes;
	setAttr ".tk[5]" -type "float3"  0 0 28.61470795;
createNode polyTweakUV -n "polyTweakUV26";
	rename -uid "1B8EFE66-46C7-F0CE-9CCE-4FB5746E53B9";
	setAttr ".uopa" yes;
	setAttr -s 4 ".uvtk";
	setAttr ".uvtk[1]" -type "float2" -0.00032002441 -0.0002301004 ;
	setAttr ".uvtk[12]" -type "float2" -7.0955548e-09 0.066644952 ;
	setAttr ".uvtk[14]" -type "float2" -2.2566087e-09 -2.7078574e-08 ;
	setAttr ".uvtk[16]" -type "float2" -0.06798587 -0.00029840611 ;
createNode polyMergeVert -n "polyMergeVert28";
	rename -uid "DBFD50AB-49C8-00CE-9BC0-5686CEFC08C1";
	setAttr ".ics" -type "componentList" 2 "vtx[1]" "vtx[12]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak60";
	rename -uid "E9C94B3D-4970-2483-B45A-4F9FF953C9E2";
	setAttr ".uopa" yes;
	setAttr ".tk[12]" -type "float3"  0 0 28.61470795;
createNode polyTweakUV -n "polyTweakUV27";
	rename -uid "13993D78-4827-0D8D-D3FD-1FA91F2B8BB7";
	setAttr ".uopa" yes;
	setAttr -s 2 ".uvtk";
	setAttr ".uvtk[3]" -type "float2" -0.0081710499 0.0084711183 ;
	setAttr ".uvtk[30]" -type "float2" 0.090102047 -0.0010803692 ;
createNode polyMergeVert -n "polyMergeVert29";
	rename -uid "B4A1E08E-478D-AE19-5679-FEA93559002C";
	setAttr ".ics" -type "componentList" 2 "vtx[3]" "vtx[19]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak61";
	rename -uid "F143C6D9-4012-0ADA-607E-BD908CA07CA3";
	setAttr ".uopa" yes;
	setAttr ".tk[19]" -type "float3"  79.85437775 0 0;
createNode polyTweakUV -n "polyTweakUV28";
	rename -uid "9DDD97B4-4764-ECFB-203B-339E16E747F1";
	setAttr ".uopa" yes;
	setAttr -s 4 ".uvtk";
	setAttr ".uvtk[1]" -type "float2" 0.00016834412 0.00054489134 ;
	setAttr ".uvtk[12]" -type "float2" 3.109778e-08 -0.0011229086 ;
	setAttr ".uvtk[28]" -type "float2" 0.099640369 0.00089050556 ;
	setAttr ".uvtk[29]" -type "float2" 0.09648066 0.0020081378 ;
createNode polyMergeVert -n "polyMergeVert30";
	rename -uid "9344FA81-4F86-87C8-2BBC-9EA9A1074A3F";
	setAttr ".ics" -type "componentList" 2 "vtx[1]" "vtx[18]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak62";
	rename -uid "2273B4D9-4EFD-5D71-80A9-CBABC35250FB";
	setAttr ".uopa" yes;
	setAttr ".tk[18]" -type "float3"  79.85437775 0 0;
createNode polyTweakUV -n "polyTweakUV29";
	rename -uid "17E15C28-4079-1900-C25E-EB8D629599F8";
	setAttr ".uopa" yes;
	setAttr -s 2 ".uvtk";
	setAttr ".uvtk[2]" -type "float2" 3.1022527e-08 3.7216128e-09 ;
	setAttr ".uvtk[36]" -type "float2" -0.041128162 0.00010347884 ;
createNode polyMergeVert -n "polyMergeVert31";
	rename -uid "A33255C8-43BE-AD5D-29C4-F385B7176F9D";
	setAttr ".ics" -type "componentList" 2 "vtx[2]" "vtx[25]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak63";
	rename -uid "9B9E1048-4F67-B805-D52F-C190DF233BB6";
	setAttr ".uopa" yes;
	setAttr ".tk[25]" -type "float3"  -7.023357391 0 0;
createNode polyTweakUV -n "polyTweakUV30";
	rename -uid "98ED0FC5-4CD6-A96D-D2E1-70B91772A1D6";
	setAttr ".uopa" yes;
	setAttr -s 4 ".uvtk";
	setAttr ".uvtk[0]" -type "float2" 0.0035171665 8.6236305e-06 ;
	setAttr ".uvtk[13]" -type "float2" 9.0654069e-08 -1.2177369e-08 ;
	setAttr ".uvtk[34]" -type "float2" -0.040606923 -0.00035733311 ;
	setAttr ".uvtk[35]" -type "float2" -0.043921016 -5.7299771e-05 ;
createNode polyMergeVert -n "polyMergeVert32";
	rename -uid "33B8DB38-41EA-203F-F2D6-FD879DE4865F";
	setAttr ".ics" -type "componentList" 2 "vtx[0]" "vtx[24]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak64";
	rename -uid "EE31573D-41ED-7F88-6EB4-11937DEAF6E6";
	setAttr ".uopa" yes;
	setAttr ".tk[24]" -type "float3"  -7.023357391 0 0;
createNode polyTweakUV -n "polyTweakUV31";
	rename -uid "B54811F3-46FA-C853-6B25-02836E2B9293";
	setAttr ".uopa" yes;
	setAttr -s 3 ".uvtk";
	setAttr ".uvtk[2]" -type "float2" 0.0054424196 0.0040015504 ;
	setAttr ".uvtk[4]" -type "float2" 0.014001019 -0.065506794 ;
	setAttr ".uvtk[21]" -type "float2" 0.081523284 -1.9751147e-05 ;
createNode polyMergeVert -n "polyMergeVert33";
	rename -uid "7B1CB120-4D46-5444-7A77-C99C83C90C38";
	setAttr ".ics" -type "componentList" 2 "vtx[2]" "vtx[4]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak65";
	rename -uid "043D617E-4AA5-A5B0-FD36-80B895BF02EA";
	setAttr ".uopa" yes;
	setAttr ".tk[4]" -type "float3"  0 0 28.61470795;
createNode polyTweakUV -n "polyTweakUV32";
	rename -uid "7F7B7762-450E-AAD8-B4A6-FAA8C21D8151";
	setAttr ".uopa" yes;
	setAttr -s 4 ".uvtk";
	setAttr ".uvtk[0]" -type "float2" 0.00086367741 -0.00031714598 ;
	setAttr ".uvtk[10]" -type "float2" 0.013074529 0.065522105 ;
	setAttr ".uvtk[12]" -type "float2" -0.0056991684 1.5505391e-05 ;
	setAttr ".uvtk[17]" -type "float2" 0.081472442 1.752131e-05 ;
createNode polyMergeVert -n "polyMergeVert34";
	rename -uid "4551F034-45F4-E011-FF95-34AFD45867F4";
	setAttr ".ics" -type "componentList" 2 "vtx[0]" "vtx[10]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak66";
	rename -uid "E3B8FB45-4650-B9C7-A1CA-BABE11FB4863";
	setAttr ".uopa" yes;
	setAttr ".tk[10]" -type "float3"  0 0 28.61470795;
createNode polyTweakUV -n "polyTweakUV33";
	rename -uid "713BA401-4C50-110E-0FA4-07A591154E89";
	setAttr ".uopa" yes;
	setAttr -s 4 ".uvtk";
	setAttr ".uvtk[4]" -type "float2" -0.0014950194 0.12257934 ;
	setAttr ".uvtk[6]" -type "float2" 4.2234621e-08 -1.1107354e-08 ;
	setAttr ".uvtk[16]" -type "float2" 1.6195218e-08 6.1264516e-10 ;
	setAttr ".uvtk[17]" -type "float2" -0.12549691 5.9350088e-05 ;
createNode polyMergeVert -n "polyMergeVert35";
	rename -uid "C8B5B7AE-4B23-FFA3-837F-BCA5FC089536";
	setAttr ".ics" -type "componentList" 2 "vtx[4]" "vtx[6]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak67";
	rename -uid "5B796756-4F93-CC98-0416-C0886CE2BC00";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[4]" -type "float3" 0 0 -46.385288 ;
	setAttr ".tk[6]" -type "float3" 0 0 3.8146973e-06 ;
createNode polyTweakUV -n "polyTweakUV34";
	rename -uid "69B70846-4C30-E2A8-8577-2D8ADA60DF59";
	setAttr ".uopa" yes;
	setAttr -s 4 ".uvtk";
	setAttr ".uvtk[6]" -type "float2" -9.33954e-05 -0.00015128151 ;
	setAttr ".uvtk[8]" -type "float2" -0.0010194862 -0.12271838 ;
	setAttr ".uvtk[13]" -type "float2" 1.705124e-08 3.1290632e-09 ;
	setAttr ".uvtk[14]" -type "float2" -0.12509897 -9.4567797e-05 ;
createNode polyMergeVert -n "polyMergeVert36";
	rename -uid "701384B6-469E-A7AC-68AE-C1B0F38C489A";
	setAttr ".ics" -type "componentList" 2 "vtx[6]" "vtx[8]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak68";
	rename -uid "0E815FA3-442F-07BE-815A-65AFD256E48D";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[6]" -type "float3" 0 0 3.8146973e-06 ;
	setAttr ".tk[8]" -type "float3" 0 0 -46.385288 ;
createNode polyTweakUV -n "polyTweakUV35";
	rename -uid "E67EFA75-4771-C0B0-2ECB-B9A5C79BFCEB";
	setAttr ".uopa" yes;
	setAttr -s 3 ".uvtk";
	setAttr ".uvtk[4]" -type "float2" 0.0012240608 0.0011194532 ;
	setAttr ".uvtk[13]" -type "float2" -0.00035587422 0.00012557392 ;
	setAttr ".uvtk[22]" -type "float2" -0.06596949 -0.00043440526 ;
createNode polyMergeVert -n "polyMergeVert37";
	rename -uid "B9483060-4D45-412E-D37C-D69704617695";
	setAttr ".ics" -type "componentList" 2 "vtx[4]" "vtx[16]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak69";
	rename -uid "054037B1-4CC4-61E8-FDEA-27809D97B39C";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[4]" -type "float3" 0 0 3.8146973e-06 ;
	setAttr ".tk[16]" -type "float3" -7.0233574 0 7.6293945e-06 ;
createNode polyTweakUV -n "polyTweakUV36";
	rename -uid "A624A953-4E03-4366-6681-71851C65324E";
	setAttr ".uopa" yes;
	setAttr -s 3 ".uvtk";
	setAttr ".uvtk[6]" -type "float2" 0.0012278039 -0.0012505979 ;
	setAttr ".uvtk[12]" -type "float2" 0.00026692273 -9.4178788e-05 ;
	setAttr ".uvtk[22]" -type "float2" -0.065740168 0.00042128339 ;
createNode polyMergeVert -n "polyMergeVert38";
	rename -uid "A0869C0D-46A8-50DA-4D4D-979D917C5A5B";
	setAttr ".ics" -type "componentList" 2 "vtx[6]" "vtx[16]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak70";
	rename -uid "CD2E1279-4E07-6CF9-EFB5-9BAB80D89C0B";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[6]" -type "float3" 0 0 3.8146973e-06 ;
	setAttr ".tk[16]" -type "float3" -7.0233574 0 7.6293945e-06 ;
createNode polyTweakUV -n "polyTweakUV37";
	rename -uid "C0CE2F45-4AFD-9F9D-0C31-698D0AB64E29";
	setAttr ".uopa" yes;
	setAttr -s 3 ".uvtk";
	setAttr ".uvtk[5]" -type "float2" -9.7228469e-05 0.0011170917 ;
	setAttr ".uvtk[11]" -type "float2" -0.0021697734 0.0006048794 ;
	setAttr ".uvtk[16]" -type "float2" 0.10385607 -0.00027965219 ;
createNode polyMergeVert -n "polyMergeVert39";
	rename -uid "AB857AB0-4B04-948D-2909-A7B92D2E962E";
	setAttr ".ics" -type "componentList" 2 "vtx[5]" "vtx[10]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak71";
	rename -uid "D717AA77-4F49-B9AF-F325-8BA19EE9E6FE";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[5]" -type "float3" 0 0 3.8146973e-06 ;
	setAttr ".tk[10]" -type "float3" 79.854378 0 7.6293945e-06 ;
createNode polyTweakUV -n "polyTweakUV38";
	rename -uid "71B48009-4545-BE5A-8703-1E90C22C0D77";
	setAttr ".uopa" yes;
	setAttr -s 4 ".uvtk";
	setAttr ".uvtk[7]" -type "float2" 0.00057251909 -0.0012033707 ;
	setAttr ".uvtk[10]" -type "float2" 0.001627304 -0.00045366163 ;
	setAttr ".uvtk[16]" -type "float2" 0.1190872 0.00044772189 ;
createNode polyMergeVert -n "polyMergeVert40";
	rename -uid "93F632EB-41EF-D7EE-2B94-15A2BE3C4909";
	setAttr ".ics" -type "componentList" 2 "vtx[7]" "vtx[10]";
	setAttr ".ix" -type "matrix" 7 0 0 0 0 0.24400001606165747 0 0 0 0 4 0 0 4.4234967355927495 -222.15249097351654 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak72";
	rename -uid "0921DBF3-4C36-69CE-3CDD-7A8A55ECD008";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[7]" -type "float3" 0 0 3.8146973e-06 ;
	setAttr ".tk[10]" -type "float3" 79.854378 0 7.6293945e-06 ;
createNode polyCube -n "polyCube9";
	rename -uid "0173533A-4275-F284-A728-E6B49C335C95";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".w" 1;
	setAttr ".h" 1;
	setAttr ".d" 1;
	setAttr ".sw" 3;
	setAttr ".sd" 3;
	setAttr ".cuv" 4;
createNode polyTweak -n "polyTweak73";
	rename -uid "F95EA1A0-48A9-3ED4-8CB1-1A8D3DD19867";
	setAttr ".uopa" yes;
	setAttr -s 24 ".tk";
	setAttr ".tk[1]" -type "float3" -19.668568 0 0 ;
	setAttr ".tk[2]" -type "float3" 19.668568 0 0 ;
	setAttr ".tk[5]" -type "float3" -19.668568 0 0 ;
	setAttr ".tk[6]" -type "float3" 19.668568 0 0 ;
	setAttr ".tk[8]" -type "float3" 0 0 19.73905 ;
	setAttr ".tk[9]" -type "float3" -19.668568 0 19.73905 ;
	setAttr ".tk[10]" -type "float3" 19.668568 0 19.73905 ;
	setAttr ".tk[11]" -type "float3" 0 0 19.73905 ;
	setAttr ".tk[12]" -type "float3" 0 0 -19.739044 ;
	setAttr ".tk[13]" -type "float3" -19.668568 0 -19.739044 ;
	setAttr ".tk[14]" -type "float3" 19.668568 0 -19.739044 ;
	setAttr ".tk[15]" -type "float3" 0 0 -19.739044 ;
	setAttr ".tk[17]" -type "float3" -19.668568 0 0 ;
	setAttr ".tk[18]" -type "float3" 19.668568 0 0 ;
	setAttr ".tk[21]" -type "float3" -19.668568 0 0 ;
	setAttr ".tk[22]" -type "float3" 19.668568 0 0 ;
	setAttr ".tk[24]" -type "float3" 0 0 -19.739048 ;
	setAttr ".tk[25]" -type "float3" -19.668568 0 -19.739048 ;
	setAttr ".tk[26]" -type "float3" 19.668568 0 -19.739048 ;
	setAttr ".tk[27]" -type "float3" 0 0 -19.739048 ;
	setAttr ".tk[28]" -type "float3" 0 0 19.739044 ;
	setAttr ".tk[29]" -type "float3" -19.668568 0 19.739044 ;
	setAttr ".tk[30]" -type "float3" 19.668568 0 19.739044 ;
	setAttr ".tk[31]" -type "float3" 0 0 19.739044 ;
createNode deleteComponent -n "deleteComponent23";
	rename -uid "6DCDFDE4-40AC-2434-CCD2-DE9E71E96A3A";
	setAttr ".dc" -type "componentList" 2 "f[7]" "f[19]";
createNode polyBridgeEdge -n "polyBridgeEdge6";
	rename -uid "E0394D91-497A-CD3C-7CE3-61B50C3121E9";
	setAttr ".ics" -type "componentList" 6 "e[7]" "e[10]" "e[19]" "e[22]" "e[33:34]" "e[49:50]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 0.32148147484635048 0 0 0 0 1.1111111154755693 0
		 -253.80526958394589 5.7074909702125254 -186.43321014101431 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 10;
	setAttr ".sv2" 30;
	setAttr ".d" 1;
	setAttr ".sd" 1;
	setAttr ".td" 1;
createNode polyCube -n "polyCube10";
	rename -uid "6D749E9B-43B7-AC31-3763-29BC493E10A7";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".w" 1;
	setAttr ".h" 1;
	setAttr ".d" 1;
	setAttr ".sh" 2;
	setAttr ".cuv" 4;
createNode polyExtrudeFace -n "polyExtrudeFace8";
	rename -uid "073751D1-4C00-A36D-B627-93A5780E2337";
	setAttr ".ics" -type "componentList" 1 "f[1]";
	setAttr ".ix" -type "matrix" 1.0683161706054065 0 1.418489280340328 0 0 3.2158024929714002 0 0
		 -0.15975915157667256 0 0.12032046163268227 0 301.90668396825077 177.14007848018542 -350.80691489124388 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 2.9391873 2.5753512 -3.4479089 ;
	setAttr ".rs" 35496;
	setAttr ".lt" -type "double3" -4.263256414560601e-16 0 1.1239221194474629 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 2.4050291785914681 1.7714007848018543 -4.1571535582662618 ;
	setAttr ".cbx" -type "double3" 3.4733453491968751 3.3793020312875548 -2.7386642779259338 ;
createNode polySplitRing -n "polySplitRing13";
	rename -uid "84CF2CE0-40A5-D8BE-6F87-C99C68105832";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "e[20:21]" "e[23]" "e[25]";
	setAttr ".ix" -type "matrix" 1.0683161706054065 0 1.418489280340328 0 0 3.2158024929714002 0 0
		 -0.15975915157667256 0 0.12032046163268227 0 301.90668396825077 177.14007848018542 -350.80691489124388 1;
	setAttr ".wt" 0.72133570909500122;
	setAttr ".dr" no;
	setAttr ".re" 23;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 3;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak74";
	rename -uid "E2447EBF-49B9-3A00-8EBA-A5904790602D";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk[12:15]" -type "float3"  -24.40268135 2.21073365 0
		 24.40268135 2.21073365 0 24.40268135 -44.53116608 0 -24.40268135 -44.53116608 0;
createNode polySplitRing -n "polySplitRing14";
	rename -uid "DE975B9E-498F-7128-5C34-E4991BB783E5";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[6:7]" "e[14:15]";
	setAttr ".ix" -type "matrix" 1.5150088286918464 0 1.6392550613382497 0 0 3.2158024929714002 0 0
		 -0.14687803214996739 0 0.13574551068728993 0 276.88425251579145 177.1400784801852 -333.69088914926482 1;
	setAttr ".wt" 0.55885434150695801;
	setAttr ".dr" no;
	setAttr ".re" 6;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak75";
	rename -uid "95E4ECAA-426B-1791-3792-6CBE136BF396";
	setAttr ".uopa" yes;
	setAttr -s 16 ".tk";
	setAttr ".tk[2]" -type "float3" 0 5.7196517 0 ;
	setAttr ".tk[3]" -type "float3" 0 5.7196517 0 ;
	setAttr ".tk[4]" -type "float3" 0 -4.1835465 0 ;
	setAttr ".tk[5]" -type "float3" 0 -4.1835465 0 ;
	setAttr ".tk[16]" -type "float3" -2.8421709e-14 -4.2020569 -1.7053026e-13 ;
	setAttr ".tk[17]" -type "float3" 0 0.71931481 0 ;
	setAttr ".tk[18]" -type "float3" 0 0.71931481 0 ;
	setAttr ".tk[19]" -type "float3" -2.8421709e-14 -4.2020569 -1.7053026e-13 ;
	setAttr ".tk[20]" -type "float3" 0 -7.8399448 -19.25882 ;
	setAttr ".tk[21]" -type "float3" 0 1.5342122 0 ;
	setAttr ".tk[22]" -type "float3" 0 1.5342122 0 ;
	setAttr ".tk[23]" -type "float3" 0 -7.8399448 -19.25882 ;
	setAttr ".tk[24]" -type "float3" -0.53676903 -6.2150249 -31.926313 ;
	setAttr ".tk[25]" -type "float3" 0 3.0007844 0 ;
	setAttr ".tk[26]" -type "float3" 0 3.0007844 0 ;
	setAttr ".tk[27]" -type "float3" -0.53676903 -6.2150249 -31.926313 ;
createNode polyExtrudeFace -n "polyExtrudeFace9";
	rename -uid "1DE3289B-448E-3A73-6E53-0690EB972038";
	setAttr ".ics" -type "componentList" 1 "f[33]";
	setAttr ".ix" -type "matrix" 1.5150088286918464 0 1.6392550613382497 0 0 3.2158024929714002 0 0
		 -0.14687803214996739 0 0.13574551068728993 0 276.88425251579145 177.1400784801852 -333.69088914926482 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 2.6954038 0.81560987 -3.2690363 ;
	setAttr ".rs" 63959;
	setAttr ".lt" -type "double3" 4.263256414560601e-16 -2.8421709430404008e-16 1.1590373036047004 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 1.9378992799469523 0.77247312108749688 -4.0886641858259205 ;
	setAttr ".cbx" -type "double3" 3.4529079234288544 0.85874661845366507 -2.4494086054798783 ;
createNode polyTweak -n "polyTweak76";
	rename -uid "826F1085-4E50-858F-60F2-578B74DF0123";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[28:35]" -type "float3"  0 -15.52672577 0 0 -12.2644043
		 0 0 -12.2644043 0 0 -15.52672577 0 0 0.36368996 0 0 1.99485183 0 0 1.99485183 0 0
		 0.36368996 0;
createNode polyCube -n "polyCube11";
	rename -uid "F0DC1D7B-4917-E610-33D5-9F902B0DEEAB";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".w" 1;
	setAttr ".h" 1;
	setAttr ".d" 1;
	setAttr ".cuv" 4;
createNode polySplitRing -n "polySplitRing15";
	rename -uid "3D355231-47C6-5785-3D22-F99DD38B7BF1";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 15 "e[0:5]" "e[22]" "e[26]" "e[32]" "e[35]" "e[40]" "e[43]" "e[48]" "e[51]" "e[56]" "e[59]" "e[64]" "e[67]" "e[70]" "e[74]";
	setAttr ".ix" -type "matrix" 1.5150088286918464 0 1.6392550613382497 0 0 3.2158024929714002 0 0
		 -0.14687803214996739 0 0.13574551068728993 0 276.88425251579145 177.1400784801852 -333.69088914926482 1;
	setAttr ".wt" 0.51383864879608154;
	setAttr ".dr" no;
	setAttr ".re" 3;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak77";
	rename -uid "1C271C92-4329-247C-514C-69B59AA79872";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk";
	setAttr ".tk[28]" -type "float3" -5.6843419e-14 8.0391493 -7.1054274e-15 ;
	setAttr ".tk[31]" -type "float3" -5.6843419e-14 8.0391493 -7.1054274e-15 ;
	setAttr ".tk[32]" -type "float3" -5.6843419e-14 8.0391493 -7.1054274e-15 ;
	setAttr ".tk[35]" -type "float3" -5.6843419e-14 8.0391493 -7.1054274e-15 ;
	setAttr ".tk[36]" -type "float3" -5.6843419e-14 8.0391493 0 ;
	setAttr ".tk[37]" -type "float3" -21.097267 8.0391493 0.81770217 ;
	setAttr ".tk[38]" -type "float3" -5.6843419e-14 8.0391493 0 ;
	setAttr ".tk[39]" -type "float3" -21.097267 8.0391493 0.81770217 ;
createNode polyDelEdge -n "polyDelEdge43";
	rename -uid "935178AA-48B3-1F79-E57E-418F1BEF6CB4";
	setAttr ".ics" -type "componentList" 19 "e[78]" "e[80]" "e[82]" "e[84]" "e[86]" "e[88]" "e[90]" "e[92]" "e[94]" "e[96]" "e[98]" "e[100]" "e[102]" "e[104]" "e[106]" "e[108]" "e[110]" "e[112]" "e[114:115]";
	setAttr ".cv" yes;
createNode polyTweak -n "polyTweak78";
	rename -uid "6789EE48-4772-406C-D4BC-1D882E62B58F";
	setAttr ".uopa" yes;
	setAttr -s 60 ".tk[0:59]" -type "float3"  4.9591064e-05 2.2888184e-05
		 -1.7166138e-05 4.9591064e-05 2.2888184e-05 -1.7166138e-05 4.9591064e-05 4.7683716e-07
		 -1.7166138e-05 4.9591064e-05 4.7683716e-07 -1.7166138e-05 4.9591064e-05 2.2888184e-05
		 -1.7166138e-05 4.9591064e-05 2.2888184e-05 -1.7166138e-05 4.9591064e-05 2.2888184e-05
		 5.7220459e-06 4.196167e-05 2.2888184e-05 5.7220459e-06 4.9591064e-05 2.3357666e-06
		 5.7220459e-06 4.196167e-05 2.3357666e-06 5.7220459e-06 4.9591064e-05 2.2888184e-05
		 5.7220459e-06 4.196167e-05 2.2888184e-05 5.7220459e-06 -6.1035156e-05 2.3841858e-07
		 0.00036811829 -3.8146973e-05 2.3841858e-07 0.00036811829 -3.8146973e-05 4.7683716e-07
		 0.00036811829 -6.1035156e-05 4.7683716e-07 0.00036811829 -3.8146973e-05 0 0.00039863586
		 -3.8146973e-05 2.3841858e-07 0.00039863586 -4.5776367e-05 2.3841858e-07 0.00039863586
		 -4.5776367e-05 0 0.00039863586 4.196167e-05 2.2888184e-05 0.00039863586 4.196167e-05
		 2.3841858e-07 0.00039863586 5.7220459e-05 2.3841858e-07 0.00039863586 6.4849854e-05
		 2.2888184e-05 0.00039863586 4.9591064e-05 2.2888184e-05 -1.335144e-05 5.7220459e-05
		 2.3841858e-07 -1.335144e-05 5.7220459e-05 2.3841858e-07 -1.335144e-05 4.9591064e-05
		 2.2888184e-05 -1.335144e-05 4.9591064e-05 2.2888184e-05 -1.7166138e-05 4.9591064e-05
		 2.2888184e-05 5.7220459e-06 4.196167e-05 2.2888184e-05 5.7220459e-06 4.9591064e-05
		 2.2888184e-05 -1.7166138e-05 4.9591064e-05 2.2888184e-05 -1.7166138e-05 4.9591064e-05
		 2.2888184e-05 5.7220459e-06 4.196167e-05 2.2888184e-05 5.7220459e-06 4.9591064e-05
		 2.2888184e-05 -1.7166138e-05 4.9591064e-05 2.2888184e-05 0.00036811829 -3.0517578e-05
		 2.2888184e-05 0.00036811829 4.9591064e-05 2.2888184e-05 0.00036811829 -3.0517578e-05
		 2.2888184e-05 0.00036811829 7.6293945e-06 2.2888184e-05 5.7220459e-06 7.6293945e-06
		 2.3357666e-06 5.7220459e-06 7.6293945e-06 2.2888184e-05 5.7220459e-06 7.6293945e-06
		 2.2888184e-05 5.7220459e-06 7.6293945e-06 2.2888184e-05 5.7220459e-06 3.8146973e-06
		 2.2888184e-05 -1.7166138e-05 3.8146973e-06 2.2888184e-05 -1.7166138e-05 -3.8146973e-06
		 2.2888184e-05 0.00036811829 -3.8146973e-06 2.2888184e-05 0.00036811829 3.8146973e-06
		 2.2888184e-05 -1.7166138e-05 3.8146973e-06 4.7683716e-07 -1.7166138e-05 1.9073486e-05
		 2.3841858e-07 -1.335144e-05 1.1444092e-05 2.3841858e-07 0.00039863586 7.6293945e-06
		 2.3841858e-07 0.00039863586 7.6293945e-06 2.3841858e-07 0.00036811829 7.6293945e-06
		 4.7683716e-07 0.00036811829 7.6293945e-06 0 0.00039863586 1.5258789e-05 2.2888184e-05
		 0.00039863586 1.9073486e-05 2.2888184e-05 -1.335144e-05 3.8146973e-06 2.2888184e-05
		 -1.7166138e-05;
createNode polyExtrudeFace -n "polyExtrudeFace10";
	rename -uid "EAAD42A4-4F0E-7D03-F003-65AB6F871EB7";
	setAttr ".ics" -type "componentList" 1 "f[4:5]";
	setAttr ".ix" -type "matrix" 0.045720445262587908 0 0.049470491141009515 0 0 0.13503009796199086 0 0
		 -0.49601665535037304 0 0.45841676153239586 0 234.5802145753776 337.93023681640625 -294.23792472217116 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 2.3458021 3.3793023 -2.9423792 ;
	setAttr ".rs" 48535;
	setAttr ".lt" -type "double3" -1.4210854715202004e-16 5.6843418860808016e-16 0.1549028960643227 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 2.0749335954472956 3.3117873191830673 -3.1963228735584144 ;
	setAttr ".cbx" -type "double3" 2.6166706960602562 3.4468174171450578 -2.6884356208850089 ;
createNode polyExtrudeFace -n "polyExtrudeFace11";
	rename -uid "FC207EAF-4C5D-1850-D392-4BA7FBFE52B0";
	setAttr ".ics" -type "componentList" 1 "f[4:5]";
	setAttr ".ix" -type "matrix" 0.045720445262587908 0 0.049470491141009515 0 0 0.13503009796199086 0 0
		 -0.49601665535037304 0 0.45841676153239586 0 234.5802145753776 337.93023681640625 -294.23792472217116 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 2.3458021 3.2716031 -2.9423792 ;
	setAttr ".rs" 33341;
	setAttr ".lt" -type "double3" 2.5890400934258651e-15 -3.552713678800501e-17 0.34486690095854738 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 1.9593098500405646 3.2495255789113271 -3.3214304077872359 ;
	setAttr ".cbx" -type "double3" 2.7322947203212329 3.2936808082993054 -2.5633282106995847 ;
createNode polyTweak -n "polyTweak79";
	rename -uid "8EBA78C8-4E41-2BA0-AE4E-FF8544692381";
	setAttr ".uopa" yes;
	setAttr -s 16 ".tk[0:15]" -type "float3"  0 0 -4.7683716e-07 0 0 -4.7683716e-07
		 0 0 -4.7683716e-07 0 0 -4.7683716e-07 0 0 -4.7683716e-07 0 0 -4.7683716e-07 0 0 -4.7683716e-07
		 0 0 -4.7683716e-07 -22.93889999 -46.10977173 2.6702881e-05 -22.93883133 -46.1096611
		 2.6702881e-05 22.93854523 -113.40936279 -2.6702881e-05 22.93859863 -113.40924072
		 -2.6702881e-05 22.93870354 -46.10971069 2.6702881e-05 22.93881989 -46.10971069 2.6702881e-05
		 -22.93863869 -113.40927124 -2.6702881e-05 -22.93873215 -113.40927124 -2.6702881e-05;
createNode polyExtrudeFace -n "polyExtrudeFace12";
	rename -uid "B25FD3CE-4DC0-87EC-BCE0-848C073C6B35";
	setAttr ".ics" -type "componentList" 1 "f[4:5]";
	setAttr ".ix" -type "matrix" 0.045720445262587908 0 0.049470491141009515 0 0 0.13503009796199086 0 0
		 -0.49601665535037304 0 0.45841676153239586 0 234.5802145753776 337.93023681640625 -294.23792472217116 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 2.345803 3.0738535 -2.9423792 ;
	setAttr ".rs" 54104;
	setAttr ".lt" -type "double3" 1.9095836023552692e-16 2.7533531010703882e-16 0.15609036240651086 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 1.7675442920485782 3.0517749317448852 -3.528924453329338 ;
	setAttr ".cbx" -type "double3" 2.9240617051088624 3.0959320154890668 -2.3558338538909323 ;
createNode polyExtrudeFace -n "polyExtrudeFace13";
	rename -uid "30BF61E9-453A-D343-DA27-728C2A17C46B";
	setAttr ".ics" -type "componentList" 1 "f[1]";
	setAttr ".ix" -type "matrix" 0.045720445262587908 0 0.049470491141009515 0 0 0.13503009796199086 0 0
		 -0.69335807468328392 0 0.64079897267588604 0 237.37571315518855 317.6465870185861 -296.83597192072688 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 2.3737574 3.2267082 -2.9683595 ;
	setAttr ".rs" 39048;
	setAttr ".lt" -type "double3" -2.8421709430404008e-16 -4.6290827003834808e-16 0.13187842321210383 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 1.9986353742372325 3.2267079877555638 -3.3195349806846166 ;
	setAttr ".cbx" -type "double3" 2.748879514997209 3.2267079877555638 -2.6171843204407224 ;
createNode polyTweak -n "polyTweak80";
	rename -uid "0CE618D7-4A16-3093-8EA8-F7B7ECF36E2E";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk";
	setAttr ".tk[2]" -type "float3" -12.210616 -12.791912 0 ;
	setAttr ".tk[3]" -type "float3" 12.210888 -12.791912 0 ;
	setAttr ".tk[4]" -type "float3" -12.210674 -12.791912 0 ;
	setAttr ".tk[5]" -type "float3" 12.210888 -12.791912 0 ;
	setAttr ".tk[24]" -type "float3" 37.283997 25.275824 -1.3218284 ;
	setAttr ".tk[25]" -type "float3" 37.284027 25.275795 -1.3218284 ;
	setAttr ".tk[26]" -type "float3" 31.595446 21.221106 -1.3218284 ;
	setAttr ".tk[27]" -type "float3" 31.595476 21.221106 -1.3218284 ;
	setAttr ".tk[28]" -type "float3" -37.284561 25.276033 -1.3218284 ;
	setAttr ".tk[29]" -type "float3" -37.284531 25.276033 -1.3218284 ;
	setAttr ".tk[30]" -type "float3" -31.595907 21.221346 -1.3218284 ;
	setAttr ".tk[31]" -type "float3" -31.595947 21.221346 -1.3218284 ;
createNode polySplitRing -n "polySplitRing16";
	rename -uid "E5AB9D5E-42B8-9BC0-2FCB-1AA7D8E1513F";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 16 "e[6:7]" "e[10:11]" "e[14]" "e[18]" "e[22]" "e[26]" "e[30]" "e[34]" "e[38]" "e[42]" "e[46]" "e[50]" "e[54]" "e[58]" "e[64]" "e[67]";
	setAttr ".ix" -type "matrix" 0.045720445262587908 0 0.049470491141009515 0 0 0.13503009796199086 0 0
		 -0.69335807468328392 0 0.64079897267588604 0 237.37571315518855 317.6465870185861 -296.83597192072688 1;
	setAttr ".wt" 0.54924726486206055;
	setAttr ".dr" no;
	setAttr ".re" 67;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak81";
	rename -uid "30AC8957-4EFC-367D-CD7D-3E8CEFC71CD8";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk[32:35]" -type "float3"  -45.60635757 -34.55154419
		 3.048884869 45.60843277 -34.55154419 3.048881054 45.60843277 -34.55154419 -3.048882008
		 -45.60646057 -34.55154419 -3.048882008;
createNode polyExtrudeFace -n "polyExtrudeFace14";
	rename -uid "2A0DF75A-4099-C497-BE85-8882EC88848B";
	setAttr ".ics" -type "componentList" 1 "f[40:44]";
	setAttr ".ix" -type "matrix" 0.045720445262587908 0 0.049470491141009515 0 0 0.13503009796199086 0 0
		 -0.69335807468328392 0 0.64079897267588604 0 237.37571315518855 317.6465870185861 -296.83597192072688 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 2.4174514 2.963841 -3.0087399 ;
	setAttr ".rs" 39645;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 1.8419529275770108 2.8524455982587025 -3.5843430191150856 ;
	setAttr ".cbx" -type "double3" 2.9936162379693378 3.0752364414020406 -2.4338586959047901 ;
createNode polyTweak -n "polyTweak82";
	rename -uid "27853DDC-47A4-35F2-9D9B-9F9DBD5BEF42";
	setAttr ".uopa" yes;
	setAttr -s 38 ".tk";
	setAttr ".tk[0]" -type "float3" 0 -24.968536 0 ;
	setAttr ".tk[1]" -type "float3" 0 -24.968536 0 ;
	setAttr ".tk[6]" -type "float3" 0 -24.968536 0 ;
	setAttr ".tk[7]" -type "float3" 0 -24.968536 0 ;
	setAttr ".tk[8]" -type "float3" 0 -24.968536 0 ;
	setAttr ".tk[9]" -type "float3" 0 -24.968536 0 ;
	setAttr ".tk[12]" -type "float3" 0 -24.968536 0 ;
	setAttr ".tk[13]" -type "float3" 0 -24.968536 0 ;
	setAttr ".tk[16]" -type "float3" -78.949615 2.5972414 2.2888184e-05 ;
	setAttr ".tk[17]" -type "float3" -78.949432 2.5971804 3.4332275e-05 ;
	setAttr ".tk[18]" -type "float3" -78.949493 27.565903 2.2649765e-05 ;
	setAttr ".tk[19]" -type "float3" -78.949432 27.565903 1.1205673e-05 ;
	setAttr ".tk[20]" -type "float3" 78.949249 2.5975618 -1.1444092e-05 ;
	setAttr ".tk[21]" -type "float3" 78.948822 2.5975618 -1.1444092e-05 ;
	setAttr ".tk[22]" -type "float3" 78.949127 27.566101 -1.168251e-05 ;
	setAttr ".tk[23]" -type "float3" 78.949127 27.566101 -2.3841858e-07 ;
	setAttr ".tk[24]" -type "float3" 0 -24.968536 0 ;
	setAttr ".tk[25]" -type "float3" 0 -24.968536 0 ;
	setAttr ".tk[28]" -type "float3" 0 -24.968536 0 ;
	setAttr ".tk[29]" -type "float3" 0 -24.968536 0 ;
	setAttr ".tk[36]" -type "float3" 1.4582255 0 37.39666 ;
	setAttr ".tk[37]" -type "float3" 1.4582255 0 37.39666 ;
	setAttr ".tk[38]" -type "float3" 1.4582255 0 37.39666 ;
	setAttr ".tk[39]" -type "float3" 80.407349 27.566101 37.396656 ;
	setAttr ".tk[40]" -type "float3" 1.4582255 0 37.39666 ;
	setAttr ".tk[41]" -type "float3" 1.4582214 -24.968536 37.39666 ;
	setAttr ".tk[42]" -type "float3" 80.407288 2.5975618 37.396648 ;
	setAttr ".tk[43]" -type "float3" 1.4582214 -24.968536 37.39666 ;
	setAttr ".tk[44]" -type "float3" 1.4582253 -24.968536 37.39666 ;
	setAttr ".tk[45]" -type "float3" -1.4582253 -24.968536 37.39666 ;
	setAttr ".tk[46]" -type "float3" -1.4582214 -24.968536 37.39666 ;
	setAttr ".tk[47]" -type "float3" -80.407837 2.5972109 37.396687 ;
	setAttr ".tk[48]" -type "float3" -1.4582214 -24.968536 37.39666 ;
	setAttr ".tk[49]" -type "float3" -1.4582255 0 37.39666 ;
	setAttr ".tk[50]" -type "float3" -80.407715 27.565903 37.396679 ;
	setAttr ".tk[51]" -type "float3" -1.4582255 0 37.39666 ;
	setAttr ".tk[52]" -type "float3" -1.4582255 0 37.39666 ;
	setAttr ".tk[53]" -type "float3" -1.4582255 0 37.39666 ;
createNode polyMergeVert -n "polyMergeVert41";
	rename -uid "01096240-4F22-D7F3-E560-2C9865AEEC8E";
	setAttr ".ics" -type "componentList" 2 "vtx[54:55]" "vtx[58:63]";
	setAttr ".ix" -type "matrix" 0.045720445262587908 0 0.049470491141009515 0 0 0.13503009796199086 0 0
		 -0.69335807468328392 0 0.64079897267588604 0 237.37571315518855 317.6465870185861 -296.83597192072688 1;
	setAttr ".d" 0.01;
	setAttr ".am" yes;
createNode polyTweak -n "polyTweak83";
	rename -uid "D4CBE553-4638-27C1-F172-10B770AFD74B";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[54:65]" -type "float3"  256.95526123 -561.2019043
		 0 255.49751282 -561.2019043 0 0 -442.31945801 0 0 -442.31945801 0 49.94181824 -607.3112793
		 0 48.48406982 -607.3112793 0 -50.057182312 -607.3112793 0 -48.59894562 -607.3112793
		 0 -255.61187744 -561.2019043 0 -257.069885254 -561.2019043 0 0 -442.32092285 0 0
		 -442.32092285 0;
createNode polySphere -n "polySphere1";
	rename -uid "3FFF5D13-46DB-EA25-2930-098A091A5E8E";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".r" 1;
	setAttr ".sa" 16;
	setAttr ".sh" 16;
createNode polyCube -n "polyCube12";
	rename -uid "86FEE13C-4927-2210-EB8F-E288445C2BBD";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".w" 1;
	setAttr ".h" 1;
	setAttr ".d" 1;
	setAttr ".sw" 3;
	setAttr ".sh" 3;
	setAttr ".sd" 3;
	setAttr ".cuv" 4;
createNode deleteComponent -n "deleteComponent24";
	rename -uid "31A53952-453E-7A61-48A6-9DA474BD287D";
	setAttr ".dc" -type "componentList" 6 "f[7:8]" "f[10:11]" "f[13:14]" "f[16:17]" "f[19:20]" "f[42:44]";
createNode deleteComponent -n "deleteComponent25";
	rename -uid "9B3077D6-47B6-D774-AE77-8BB50E2F6FB3";
	setAttr ".dc" -type "componentList" 3 "f[5]" "f[13]" "f[29:31]";
createNode polyDelEdge -n "polyDelEdge44";
	rename -uid "22E41909-4777-4AF5-04BF-D6831D7E4DE3";
	setAttr ".ics" -type "componentList" 4 "e[9:10]" "e[20:25]" "e[65:66]" "e[73:78]";
	setAttr ".cv" yes;
createNode polyBridgeEdge -n "polyBridgeEdge7";
	rename -uid "E2720600-454A-3E8A-274A-5C936DB5C4D0";
	setAttr ".ics" -type "componentList" 2 "e[7]" "e[11]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 -71.158487025757282 80.197743178217053 -186.40000000000001 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 9;
	setAttr ".sv2" 17;
	setAttr ".d" 1;
	setAttr ".td" 1;
createNode polyBridgeEdge -n "polyBridgeEdge8";
	rename -uid "835048A2-45FF-A86B-353E-A198DC75D67D";
	setAttr ".ics" -type "componentList" 2 "e[28]" "e[46]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 -71.158487025757282 80.197743178217053 -186.40000000000001 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 14;
	setAttr ".sv2" 9;
	setAttr ".d" 1;
createNode polyBridgeEdge -n "polyBridgeEdge9";
	rename -uid "AAA20913-4241-833A-F45D-969C912D7205";
	setAttr ".ics" -type "componentList" 2 "e[5]" "e[14]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 -71.158487025757282 80.197743178217053 -186.40000000000001 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 6;
	setAttr ".sv2" 21;
	setAttr ".d" 1;
	setAttr ".td" 1;
createNode polyBridgeEdge -n "polyBridgeEdge10";
	rename -uid "1C45385F-44E7-D29D-61C4-85BA935AEE22";
	setAttr ".ics" -type "componentList" 2 "e[45]" "e[47]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 -71.158487025757282 80.197743178217053 -186.40000000000001 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 17;
	setAttr ".sv2" 6;
	setAttr ".d" 1;
createNode polyDelEdge -n "polyDelEdge45";
	rename -uid "B8B0D897-4179-8203-BFF3-468A7B578106";
	setAttr ".ics" -type "componentList" 3 "e[6]" "e[10]" "e[44]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge46";
	rename -uid "5DF0FDCF-4A01-A2D6-30CE-7FAE314FD544";
	setAttr ".ics" -type "componentList" 3 "e[3:4]" "e[10:11]" "e[39]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge47";
	rename -uid "CA431883-46BD-CC90-0B95-BDA2907FFD2B";
	setAttr ".ics" -type "componentList" 3 "e[14]" "e[23]" "e[28]";
	setAttr ".cv" yes;
createNode polyDelEdge -n "polyDelEdge48";
	rename -uid "359175E5-4470-B636-B7A9-10B29A3FAAFB";
	setAttr ".ics" -type "componentList" 3 "e[10]" "e[20]" "e[24]";
	setAttr ".cv" yes;
createNode polySplit -n "polySplit84";
	rename -uid "90DC5025-493C-4C50-B969-668D8CCC26DE";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483638 -2147483646;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit85";
	rename -uid "6D1BB58F-4C28-E552-BD27-2DB50E823021";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483648 -2147483647;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit86";
	rename -uid "89369E98-45F8-C9E2-5B51-9F84E9DF6687";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483634 -2147483641;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit87";
	rename -uid "9E8570DE-4967-E7B6-A14C-84835D77413A";
	setAttr -s 2 ".e[0:1]"  1 0;
	setAttr -s 2 ".d[0:1]"  -2147483633 -2147483641;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplitRing -n "polySplitRing17";
	rename -uid "7DEAEB20-41B6-E28D-0AEE-03A223EB8751";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 9 "e[0]" "e[25]" "e[32]" "e[39]" "e[48]" "e[55]" "e[58]" "e[62]" "e[64:75]";
	setAttr ".ix" -type "matrix" 2.0150089925931121 0 0.96028520081598745 0 0 3.2158024929714002 0 0
		 -0.086042010133214303 0 0.18054576287533267 0 233.25411476308818 177.14007848018471 -358.01158000365422 1;
	setAttr ".wt" 0.55917996168136597;
	setAttr ".dr" no;
	setAttr ".re" 71;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak84";
	rename -uid "017BB8D3-4FC1-2726-B151-A4A0450A0544";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk[36:39]" -type "float3"  -0.094924927 0 -156.93676758
		 -0.094932556 0 -156.93676758 -0.094924927 0 -156.93676758 -0.094932556 0 -156.93676758;
createNode polyDelEdge -n "polyDelEdge49";
	rename -uid "85F4F14D-4364-F590-34B7-4694AAF01AC1";
	setAttr ".ics" -type "componentList" 19 "e[78]" "e[80]" "e[82]" "e[84]" "e[86]" "e[88]" "e[90]" "e[92]" "e[94]" "e[96]" "e[98]" "e[100]" "e[102]" "e[104]" "e[106]" "e[108]" "e[110]" "e[112]" "e[114:115]";
	setAttr ".cv" yes;
createNode polyCube -n "polyCube13";
	rename -uid "D1F57CFB-485F-8562-3FE8-56A9D644B0F9";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".w" 1;
	setAttr ".h" 1;
	setAttr ".d" 1;
	setAttr ".cuv" 4;
createNode polySplitRing -n "polySplitRing18";
	rename -uid "CF6944C6-4477-A16B-5FF5-4FBED06F86DA";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[0:3]";
	setAttr ".ix" -type "matrix" 3.7200730809449007 0 0 0 0 0.52222220962852162 0 0 0 0 1.3165397738786413 0
		 -182.36897612175136 36.479411768849083 -407.23895789384721 1;
	setAttr ".wt" 0.23060289025306702;
	setAttr ".re" 1;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 8;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak85";
	rename -uid "796302F0-4B60-6EF6-0F5E-5F8C05974BE8";
	setAttr ".uopa" yes;
	setAttr -s 6 ".tk";
	setAttr ".tk[0]" -type "float3" 0 0 26.994507 ;
	setAttr ".tk[1]" -type "float3" 20.921186 0 -70.939766 ;
	setAttr ".tk[2]" -type "float3" 0 0 26.994507 ;
	setAttr ".tk[3]" -type "float3" 20.921186 0 -70.939766 ;
	setAttr ".tk[5]" -type "float3" 26.168804 0 0 ;
	setAttr ".tk[7]" -type "float3" 26.168804 0 0 ;
createNode polyCube -n "polyCube14";
	rename -uid "ACB4910B-4D3D-FE36-3FBC-6A93165E90E3";
	setAttr ".ax" -type "double3" 0 1 0 ;
	setAttr ".w" 1;
	setAttr ".h" 1;
	setAttr ".d" 1;
	setAttr ".cuv" 4;
createNode polyBridgeEdge -n "polyBridgeEdge11";
	rename -uid "B3825121-4833-521E-D410-258711FBAD13";
	setAttr ".ics" -type "componentList" 2 "e[8]" "e[10]";
	setAttr ".ix" -type "matrix" 3.7200730809449007 0 0 0 0 0.448630621820714 0 0 0 0 1.6594195568177239 0
		 -182.36897612175136 83.410552833999475 -396.71455653121552 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 5;
	setAttr ".sv2" 7;
	setAttr ".d" 1;
	setAttr ".sd" 1;
createNode polyDelEdge -n "polyDelEdge50";
	rename -uid "AEABD04A-4166-E74B-F209-BB907848D7F6";
	setAttr ".ics" -type "componentList" 2 "e[12:13]" "e[69]";
	setAttr ".cv" yes;
createNode polyTweak -n "polyTweak86";
	rename -uid "511C82A5-465C-BD73-09C3-FBA2EB2E3907";
	setAttr ".uopa" yes;
	setAttr -s 15 ".tk";
	setAttr ".tk[2]" -type "float3" 0 30.424696 0 ;
	setAttr ".tk[3]" -type "float3" 0 30.424696 0 ;
	setAttr ".tk[16]" -type "float3" 0 -0.47436884 0 ;
	setAttr ".tk[17]" -type "float3" -1.4210855e-14 5.3364086 -2.2737368e-13 ;
	setAttr ".tk[18]" -type "float3" -1.4210855e-14 5.3364086 -2.2737368e-13 ;
	setAttr ".tk[19]" -type "float3" 0 -0.47436884 0 ;
	setAttr ".tk[20]" -type "float3" 2.1316282e-14 -0.79612875 18.005453 ;
	setAttr ".tk[21]" -type "float3" 7.1054274e-15 12.885069 -18.005489 ;
	setAttr ".tk[22]" -type "float3" -2.1316282e-14 12.885069 -18.005489 ;
	setAttr ".tk[23]" -type "float3" -7.1054274e-15 -0.79613239 18.005516 ;
	setAttr ".tk[24]" -type "float3" -4.7532822e-09 -3.1224043 31.838877 ;
	setAttr ".tk[25]" -type "float3" 4.7534598e-09 22.389933 -31.838884 ;
	setAttr ".tk[26]" -type "float3" 4.7532609e-09 22.389933 -31.838884 ;
	setAttr ".tk[27]" -type "float3" -4.7534527e-09 -3.1224015 31.838896 ;
createNode polySplit -n "polySplit88";
	rename -uid "7323A3B0-474D-0E27-FCAB-9CB79830E03B";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483645 -2147483641;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit89";
	rename -uid "84A22F65-473D-E176-57B4-EBA0873FF7AF";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483611 -2147483644;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyDelEdge -n "polyDelEdge51";
	rename -uid "CA8424DF-4917-E0D3-30AE-1C899E2332FE";
	setAttr ".ics" -type "componentList" 5 "e[39]" "e[42]" "e[46]" "e[49]" "e[65:66]";
	setAttr ".cv" yes;
createNode polySplit -n "polySplit90";
	rename -uid "DDA65855-4FCF-121B-8FE1-1A8CFBC512E4";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483611 -2147483640;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit91";
	rename -uid "F9B81083-46A7-450A-3114-BA8BCE39C7FF";
	setAttr -s 2 ".e[0:1]"  0 0;
	setAttr -s 2 ".d[0:1]"  -2147483607 -2147483640;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit92";
	rename -uid "63A51FC0-4A19-3E52-4A76-AAB7B6D9D5A6";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483648 -2147483642;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit93";
	rename -uid "6C7BAF6B-4ACB-4AEA-23FC-E79368422503";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483609 -2147483642;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyMergeVert -n "polyMergeVert42";
	rename -uid "68250FC1-4042-C7C0-51CC-F480E7870F25";
	setAttr ".ics" -type "componentList" 1 "vtx[0:33]";
	setAttr ".ix" -type "matrix" 1.9330821711331834 0 1.1160655118694094 0 -0 3.2158024929714002 0 0
		 -0.099999999999999992 -0 0.17320508075688776 0 236.09767396743356 177.14007848018471 -342.10585078738023 1;
	setAttr ".d" 0.01;
	setAttr ".am" yes;
createNode polySplitRing -n "polySplitRing19";
	rename -uid "3280EE90-4768-4552-4034-A9B657E3A816";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 8 "e[19]" "e[26]" "e[33]" "e[38]" "e[42]" "e[45]" "e[49]" "e[51:60]";
	setAttr ".ix" -type "matrix" 1.880661006555489 0 1.2022990832396923 0 -0 3.2158024929714002 0 0
		 -0.10772656895613963 -0 0.16850811951042033 0 233.91321615765227 173.69734077345242 -358.30513256285002 1;
	setAttr ".wt" 0.5351678729057312;
	setAttr ".dr" no;
	setAttr ".re" 51;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak87";
	rename -uid "663A1A71-4F9E-229C-AB2C-449F232C4937";
	setAttr ".uopa" yes;
	setAttr -s 20 ".tk";
	setAttr ".tk[6]" -type "float3" -5.7220459e-06 0 -234.8801 ;
	setAttr ".tk[7]" -type "float3" 5.7220459e-06 0 -234.8801 ;
	setAttr ".tk[8]" -type "float3" -5.7220459e-06 0 -234.8801 ;
	setAttr ".tk[9]" -type "float3" 5.7220459e-06 0 -234.8801 ;
	setAttr ".tk[22]" -type "float3" 1.2285677 -0.96132982 0.10599393 ;
	setAttr ".tk[25]" -type "float3" -0.15499234 -0.96133053 0.10629338 ;
	setAttr ".tk[26]" -type "float3" 9.5367432e-07 -9.5367432e-07 5.3405762e-05 ;
	setAttr ".tk[27]" -type "float3" -9.5367432e-07 -9.5367432e-07 5.3405762e-05 ;
	setAttr ".tk[30]" -type "float3" -1.0659678 0 4.2026196 ;
	setAttr ".tk[31]" -type "float3" 22.353182 -6.1319452e-07 3.3851817 ;
	setAttr ".tk[32]" -type "float3" -1.0659661 7.7425796e-08 4.2026234 ;
	setAttr ".tk[33]" -type "float3" 22.353182 -1.1146672e-06 3.3851817 ;
createNode polyDelEdge -n "polyDelEdge52";
	rename -uid "F5221F3F-48CC-6D43-3425-77A9DB3EE3EC";
	setAttr ".ics" -type "componentList" 16 "e[69]" "e[71]" "e[73]" "e[75]" "e[77]" "e[79]" "e[81]" "e[83]" "e[85]" "e[87]" "e[89]" "e[91]" "e[93]" "e[95]" "e[97]" "e[99:100]";
	setAttr ".cv" yes;
createNode groupId -n "groupId80";
	rename -uid "98C7A145-4F80-6741-B3D5-BE8B66CFA933";
	setAttr ".ihi" 0;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 20 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 8 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
	setAttr -s 7 ".u";
select -ne :defaultRenderingList1;
select -ne :defaultTextureList1;
	setAttr -s 7 ".tx";
select -ne :initialShadingGroup;
	setAttr -s 17 ".dsm";
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	setAttr ".ren" -type "string" "arnold";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :defaultHideFaceDataSet;
	setAttr -s 2 ".dnsm";
select -ne :modelPanel2ViewSelectedSet;
	setAttr ".ihi" 0;
	setAttr -s 2 ".dsm";
connectAttr "UVRef.di" "UVPlane.do";
connectAttr "OutterRef.di" "imagePlane4.do";
connectAttr ":defaultColorMgtGlobals.cme" "imagePlaneShape4.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "imagePlaneShape4.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "imagePlaneShape4.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "imagePlaneShape4.ws";
connectAttr "OutterRef.di" "imagePlane3.do";
connectAttr ":defaultColorMgtGlobals.cme" "imagePlaneShape3.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "imagePlaneShape3.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "imagePlaneShape3.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "imagePlaneShape3.ws";
connectAttr "InnerRef.di" "imagePlane2.do";
connectAttr ":defaultColorMgtGlobals.cme" "imagePlaneShape2.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "imagePlaneShape2.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "imagePlaneShape2.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "imagePlaneShape2.ws";
connectAttr "InnerRef.di" "imagePlane1.do";
connectAttr ":defaultColorMgtGlobals.cme" "imagePlaneShape1.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "imagePlaneShape1.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "imagePlaneShape1.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "imagePlaneShape1.ws";
connectAttr ":perspShape.msg" "imagePlaneShape1.ltc";
connectAttr "transformGeometry1.og" "pCubeShape1.i";
connectAttr "polyCube2.out" "pCubeShape15.i";
connectAttr "polySoftEdge3.out" "PaperCraneShape.i";
connectAttr "polyTweakUV2.uvtk[0]" "PaperCraneShape.uvst[0].uvtw";
connectAttr "polyConnectComponents26.out" "LockShellShape.i";
connectAttr "polyTweakUV22.uvtk[0]" "LockShellShape.uvst[0].uvtw";
connectAttr "polySoftEdge4.out" "LockHoleShape.i";
connectAttr "polyCube5.out" "pCubeShape22.i";
connectAttr "polySplit26.out" "pCubeShape23.i";
connectAttr "polyCube7.out" "pCubeShape24.i";
connectAttr "polyMergeVert40.out" "pCubeShape25.i";
connectAttr "polyTweakUV38.uvtk[0]" "pCubeShape25.uvst[0].uvtw";
connectAttr "polyBridgeEdge6.out" "pCubeShape26.i";
connectAttr "polyDelEdge52.out" "pCubeShape27.i";
connectAttr "polyMergeVert41.out" "pCubeShape28.i";
connectAttr "polySphere1.out" "pSphereShape1.i";
connectAttr "polySplit87.out" "pCubeShape29.i";
connectAttr "polySplitRing18.out" "pCubeShape30.i";
connectAttr "polyCube14.out" "pCubeShape31.i";
connectAttr "polyBridgeEdge11.out" "pCubeShape34.i";
connectAttr "groupId80.id" "LadderShape.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "LadderShape.iog.og[0].gco";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "lambert2SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "lambert3SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "lambert4SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "bifrostLiquidMaterial1SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "blinn1SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "anisotropic1SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "ShaderfxGameHair1SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "lambert5SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "BoatSG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "Coach1SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "BackShellSG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "Platform1SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "PlatformDecoSG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "Left_EarSG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "Platform1SG1.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "PlatformDecoSG1.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "Left_EarSG1.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "lambert6SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "lambert2SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "lambert3SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "lambert4SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "bifrostLiquidMaterial1SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "blinn1SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "anisotropic1SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "ShaderfxGameHair1SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "lambert5SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "BoatSG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "Coach1SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "BackShellSG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "Platform1SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "PlatformDecoSG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "Left_EarSG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "Platform1SG1.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "PlatformDecoSG1.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "Left_EarSG1.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "lambert6SG.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "layerManager.dli[2]" "InnerRef.id";
connectAttr "lambert2SG.msg" "materialInfo1.sg";
connectAttr "layerManager.dli[1]" "OutterRef.id";
connectAttr "layerManager.dli[3]" "UVRef.id";
connectAttr "lambert3SG.msg" "materialInfo2.sg";
connectAttr ":defaultColorMgtGlobals.cme" "file1.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "file1.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "file1.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "file1.ws";
connectAttr "place2dTexture1.c" "file1.c";
connectAttr "place2dTexture1.tf" "file1.tf";
connectAttr "place2dTexture1.rf" "file1.rf";
connectAttr "place2dTexture1.mu" "file1.mu";
connectAttr "place2dTexture1.mv" "file1.mv";
connectAttr "place2dTexture1.s" "file1.s";
connectAttr "place2dTexture1.wu" "file1.wu";
connectAttr "place2dTexture1.wv" "file1.wv";
connectAttr "place2dTexture1.re" "file1.re";
connectAttr "place2dTexture1.of" "file1.of";
connectAttr "place2dTexture1.r" "file1.ro";
connectAttr "place2dTexture1.n" "file1.n";
connectAttr "place2dTexture1.vt1" "file1.vt1";
connectAttr "place2dTexture1.vt2" "file1.vt2";
connectAttr "place2dTexture1.vt3" "file1.vt3";
connectAttr "place2dTexture1.vc1" "file1.vc1";
connectAttr "place2dTexture1.o" "file1.uv";
connectAttr "place2dTexture1.ofs" "file1.fs";
connectAttr "lambert4SG.msg" "materialInfo3.sg";
connectAttr "place2dTexture2.o" "bulge1.uv";
connectAttr "place2dTexture2.ofs" "bulge1.fs";
connectAttr "bifrostLiquidMaterial1SG.msg" "materialInfo4.sg";
connectAttr "blinn1SG.msg" "materialInfo5.sg";
connectAttr "anisotropic1SG.msg" "materialInfo6.sg";
connectAttr "ShaderfxGameHair1SG.msg" "materialInfo7.sg";
connectAttr ":defaultColorMgtGlobals.cme" "file2.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "file2.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "file2.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "file2.ws";
connectAttr "place2dTexture3.c" "file2.c";
connectAttr "place2dTexture3.tf" "file2.tf";
connectAttr "place2dTexture3.rf" "file2.rf";
connectAttr "place2dTexture3.mu" "file2.mu";
connectAttr "place2dTexture3.mv" "file2.mv";
connectAttr "place2dTexture3.s" "file2.s";
connectAttr "place2dTexture3.wu" "file2.wu";
connectAttr "place2dTexture3.wv" "file2.wv";
connectAttr "place2dTexture3.re" "file2.re";
connectAttr "place2dTexture3.of" "file2.of";
connectAttr "place2dTexture3.r" "file2.ro";
connectAttr "place2dTexture3.n" "file2.n";
connectAttr "place2dTexture3.vt1" "file2.vt1";
connectAttr "place2dTexture3.vt2" "file2.vt2";
connectAttr "place2dTexture3.vt3" "file2.vt3";
connectAttr "place2dTexture3.vc1" "file2.vc1";
connectAttr "place2dTexture3.o" "file2.uv";
connectAttr "place2dTexture3.ofs" "file2.fs";
connectAttr ":defaultColorMgtGlobals.cme" "file3.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "file3.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "file3.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "file3.ws";
connectAttr "place2dTexture4.c" "file3.c";
connectAttr "place2dTexture4.tf" "file3.tf";
connectAttr "place2dTexture4.rf" "file3.rf";
connectAttr "place2dTexture4.mu" "file3.mu";
connectAttr "place2dTexture4.mv" "file3.mv";
connectAttr "place2dTexture4.s" "file3.s";
connectAttr "place2dTexture4.wu" "file3.wu";
connectAttr "place2dTexture4.wv" "file3.wv";
connectAttr "place2dTexture4.re" "file3.re";
connectAttr "place2dTexture4.of" "file3.of";
connectAttr "place2dTexture4.r" "file3.ro";
connectAttr "place2dTexture4.n" "file3.n";
connectAttr "place2dTexture4.vt1" "file3.vt1";
connectAttr "place2dTexture4.vt2" "file3.vt2";
connectAttr "place2dTexture4.vt3" "file3.vt3";
connectAttr "place2dTexture4.vc1" "file3.vc1";
connectAttr "place2dTexture4.o" "file3.uv";
connectAttr "place2dTexture4.ofs" "file3.fs";
connectAttr "lambert5SG.msg" "materialInfo8.sg";
connectAttr "BoatSG.msg" "materialInfo9.sg";
connectAttr "Coach1SG.msg" "materialInfo10.sg";
connectAttr "BackShellSG.msg" "materialInfo11.sg";
connectAttr "place2dTexture5.o" "file4.uv";
connectAttr "place2dTexture5.ofu" "file4.ofu";
connectAttr "place2dTexture5.ofv" "file4.ofv";
connectAttr "place2dTexture5.rf" "file4.rf";
connectAttr "place2dTexture5.reu" "file4.reu";
connectAttr "place2dTexture5.rev" "file4.rev";
connectAttr "place2dTexture5.vt1" "file4.vt1";
connectAttr "place2dTexture5.vt2" "file4.vt2";
connectAttr "place2dTexture5.vt3" "file4.vt3";
connectAttr "place2dTexture5.vc1" "file4.vc1";
connectAttr "place2dTexture5.ofs" "file4.fs";
connectAttr "Platform1SG.msg" "materialInfo12.sg";
connectAttr "PlatformDecoSG.msg" "materialInfo13.sg";
connectAttr "Left_EarSG.msg" "materialInfo14.sg";
connectAttr "place2dTexture6.o" "file5.uv";
connectAttr "place2dTexture6.ofu" "file5.ofu";
connectAttr "place2dTexture6.ofv" "file5.ofv";
connectAttr "place2dTexture6.rf" "file5.rf";
connectAttr "place2dTexture6.reu" "file5.reu";
connectAttr "place2dTexture6.rev" "file5.rev";
connectAttr "place2dTexture6.vt1" "file5.vt1";
connectAttr "place2dTexture6.vt2" "file5.vt2";
connectAttr "place2dTexture6.vt3" "file5.vt3";
connectAttr "place2dTexture6.vc1" "file5.vc1";
connectAttr "place2dTexture6.ofs" "file5.fs";
connectAttr "file1.oc" "InnerMat.c";
connectAttr "InnerMat.oc" "Platform1SG1.ss";
connectAttr "Platform1SG1.msg" "materialInfo15.sg";
connectAttr "InnerMat.msg" "materialInfo15.m";
connectAttr "file1.msg" "materialInfo15.t" -na;
connectAttr "CutoutMat.oc" "PlatformDecoSG1.ss";
connectAttr "pCubeShape13.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape12.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape11.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape10.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape9.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape8.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape7.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape6.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape5.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape4.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape3.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape2.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape1.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape14.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape19.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape18.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape17.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape16.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "pCubeShape15.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "LockHoleShape.iog" "PlatformDecoSG1.dsm" -na;
connectAttr "PlatformDecoSG1.msg" "materialInfo16.sg";
connectAttr "CutoutMat.msg" "materialInfo16.m";
connectAttr "file6.oc" "OutterMat.c";
connectAttr "file6.ot" "OutterMat.it";
connectAttr "OutterMat.oc" "Left_EarSG1.ss";
connectAttr "LockShellShape.iog" "Left_EarSG1.dsm" -na;
connectAttr "Left_EarSG1.msg" "materialInfo17.sg";
connectAttr "OutterMat.msg" "materialInfo17.m";
connectAttr "file6.msg" "materialInfo17.t" -na;
connectAttr "place2dTexture7.o" "file6.uv";
connectAttr "place2dTexture7.ofu" "file6.ofu";
connectAttr "place2dTexture7.ofv" "file6.ofv";
connectAttr "place2dTexture7.rf" "file6.rf";
connectAttr "place2dTexture7.reu" "file6.reu";
connectAttr "place2dTexture7.rev" "file6.rev";
connectAttr "place2dTexture7.vt1" "file6.vt1";
connectAttr "place2dTexture7.vt2" "file6.vt2";
connectAttr "place2dTexture7.vt3" "file6.vt3";
connectAttr "place2dTexture7.vc1" "file6.vc1";
connectAttr "place2dTexture7.ofs" "file6.fs";
connectAttr ":defaultColorMgtGlobals.cme" "file6.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "file6.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "file6.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "file6.ws";
connectAttr "Water.oc" "lambert6SG.ss";
connectAttr "lambert6SG.msg" "materialInfo18.sg";
connectAttr "Water.msg" "materialInfo18.m";
connectAttr "polyCube1.out" "transformGeometry1.ig";
connectAttr "Left_EarSG1.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[0].dn"
		;
connectAttr "file3.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[1].dn"
		;
connectAttr "blinn1SG.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[2].dn"
		;
connectAttr "OutterMat.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[3].dn"
		;
connectAttr "CutoutMat.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[4].dn"
		;
connectAttr "place2dTexture4.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[5].dn"
		;
connectAttr "Water.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[6].dn"
		;
connectAttr "place2dTexture3.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[7].dn"
		;
connectAttr "file2.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[8].dn"
		;
connectAttr "ShaderfxGameHair1SG.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[9].dn"
		;
connectAttr "place2dTexture7.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[10].dn"
		;
connectAttr "PlatformDecoSG1.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[11].dn"
		;
connectAttr "InnerMat.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[12].dn"
		;
connectAttr "Platform1SG1.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[13].dn"
		;
connectAttr "lambert6SG.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[14].dn"
		;
connectAttr "file6.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[15].dn"
		;
connectAttr "anisotropic1SG.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[16].dn"
		;
connectAttr "lambert5SG.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[17].dn"
		;
connectAttr "bifrostLiquidMaterial1SG.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[18].dn"
		;
connectAttr "polyCube3.out" "polyTweak1.ip";
connectAttr "polyTweak1.out" "polySplit1.ip";
connectAttr "polySplit1.out" "polySplit2.ip";
connectAttr "polySplit2.out" "polySplit3.ip";
connectAttr "polySplit3.out" "polySplit4.ip";
connectAttr "polySplit4.out" "polyTweak2.ip";
connectAttr "polyTweak2.out" "polySplit5.ip";
connectAttr "polySplit5.out" "polySplit6.ip";
connectAttr "polySplit6.out" "polySplit7.ip";
connectAttr "polySplit7.out" "polySplit8.ip";
connectAttr "polySplit8.out" "deleteComponent1.ig";
connectAttr "deleteComponent1.og" "deleteComponent2.ig";
connectAttr "deleteComponent2.og" "deleteComponent3.ig";
connectAttr "deleteComponent3.og" "deleteComponent4.ig";
connectAttr "deleteComponent4.og" "deleteComponent5.ig";
connectAttr "deleteComponent5.og" "deleteComponent6.ig";
connectAttr "deleteComponent6.og" "deleteComponent7.ig";
connectAttr "deleteComponent7.og" "deleteComponent8.ig";
connectAttr "deleteComponent8.og" "deleteComponent9.ig";
connectAttr "deleteComponent9.og" "deleteComponent10.ig";
connectAttr "polyTweak3.out" "polyDelEdge1.ip";
connectAttr "deleteComponent10.og" "polyTweak3.ip";
connectAttr "polyDelEdge1.out" "polyDelEdge2.ip";
connectAttr "polyDelEdge2.out" "polyDelEdge3.ip";
connectAttr "polyDelEdge3.out" "polyDelEdge4.ip";
connectAttr "polyDelEdge4.out" "polyTweak4.ip";
connectAttr "polyTweak4.out" "deleteComponent11.ig";
connectAttr "deleteComponent11.og" "deleteComponent12.ig";
connectAttr "deleteComponent12.og" "deleteComponent13.ig";
connectAttr "deleteComponent13.og" "deleteComponent14.ig";
connectAttr "polyTweak5.out" "polyBridgeEdge1.ip";
connectAttr "PaperCraneShape.wm" "polyBridgeEdge1.mp";
connectAttr "deleteComponent14.og" "polyTweak5.ip";
connectAttr "polyBridgeEdge1.out" "polyBridgeEdge2.ip";
connectAttr "PaperCraneShape.wm" "polyBridgeEdge2.mp";
connectAttr "polyBridgeEdge2.out" "polyMergeVert1.ip";
connectAttr "PaperCraneShape.wm" "polyMergeVert1.mp";
connectAttr "polyMergeVert1.out" "polySplitRing1.ip";
connectAttr "PaperCraneShape.wm" "polySplitRing1.mp";
connectAttr "polySplitRing1.out" "polySplitRing2.ip";
connectAttr "PaperCraneShape.wm" "polySplitRing2.mp";
connectAttr "polySplitRing2.out" "polySplitRing3.ip";
connectAttr "PaperCraneShape.wm" "polySplitRing3.mp";
connectAttr "polySplitRing3.out" "polySplitRing4.ip";
connectAttr "PaperCraneShape.wm" "polySplitRing4.mp";
connectAttr "polySplitRing4.out" "polySplit9.ip";
connectAttr "polySplit9.out" "polySplit10.ip";
connectAttr "polySplit10.out" "polySplit11.ip";
connectAttr "polySplit11.out" "polySplit12.ip";
connectAttr "polySplit12.out" "polyTweak6.ip";
connectAttr "polyTweak6.out" "polySplit13.ip";
connectAttr "polySplit13.out" "polySplit14.ip";
connectAttr "polySplit14.out" "polySplit15.ip";
connectAttr "polySplit15.out" "polySplit16.ip";
connectAttr "polySplit16.out" "polySplit17.ip";
connectAttr "polySplit17.out" "polySplit18.ip";
connectAttr "polySplit18.out" "polySplit19.ip";
connectAttr "polySplit19.out" "polySplit20.ip";
connectAttr "polySplit20.out" "polyTweak7.ip";
connectAttr "polyTweak7.out" "deleteComponent15.ig";
connectAttr "deleteComponent15.og" "polyTweakUV1.ip";
connectAttr "polyTweak8.out" "polyMergeVert2.ip";
connectAttr "PaperCraneShape.wm" "polyMergeVert2.mp";
connectAttr "polyTweakUV1.out" "polyTweak8.ip";
connectAttr "polyMergeVert2.out" "polyTweakUV2.ip";
connectAttr "polyTweak9.out" "polyMergeVert3.ip";
connectAttr "PaperCraneShape.wm" "polyMergeVert3.mp";
connectAttr "polyTweakUV2.out" "polyTweak9.ip";
connectAttr "polyTweak10.out" "polyDelEdge5.ip";
connectAttr "polyMergeVert3.out" "polyTweak10.ip";
connectAttr "polyTweak11.out" "polyMergeVert4.ip";
connectAttr "PaperCraneShape.wm" "polyMergeVert4.mp";
connectAttr "polyDelEdge5.out" "polyTweak11.ip";
connectAttr "polyMergeVert4.out" "polyTweak12.ip";
connectAttr "polyTweak12.out" "polySplit21.ip";
connectAttr "polySplit21.out" "polySplit22.ip";
connectAttr "polyTweak13.out" "polySoftEdge1.ip";
connectAttr "PaperCraneShape.wm" "polySoftEdge1.mp";
connectAttr "polySplit22.out" "polyTweak13.ip";
connectAttr "polySoftEdge1.out" "polySoftEdge2.ip";
connectAttr "PaperCraneShape.wm" "polySoftEdge2.mp";
connectAttr "polySoftEdge2.out" "polySoftEdge3.ip";
connectAttr "PaperCraneShape.wm" "polySoftEdge3.mp";
connectAttr "polyTweak14.out" "polySplitRing5.ip";
connectAttr "LockShellShape.wm" "polySplitRing5.mp";
connectAttr "polyCube4.out" "polyTweak14.ip";
connectAttr "polySplitRing5.out" "polyTweak15.ip";
connectAttr "polyTweak15.out" "deleteComponent16.ig";
connectAttr "deleteComponent16.og" "polyExtrudeEdge1.ip";
connectAttr "LockShellShape.wm" "polyExtrudeEdge1.mp";
connectAttr "polyTweak16.out" "polyExtrudeFace1.ip";
connectAttr "LockShellShape.wm" "polyExtrudeFace1.mp";
connectAttr "polyExtrudeEdge1.out" "polyTweak16.ip";
connectAttr "polyTweak17.out" "polyCloseBorder1.ip";
connectAttr "polyExtrudeFace1.out" "polyTweak17.ip";
connectAttr "polyTweak18.out" "polySplitRing6.ip";
connectAttr "LockShellShape.wm" "polySplitRing6.mp";
connectAttr "polyCloseBorder1.out" "polyTweak18.ip";
connectAttr "polyTweak19.out" "polyExtrudeFace2.ip";
connectAttr "LockShellShape.wm" "polyExtrudeFace2.mp";
connectAttr "polySplitRing6.out" "polyTweak19.ip";
connectAttr "polyTweak20.out" "polySplitRing7.ip";
connectAttr "LockShellShape.wm" "polySplitRing7.mp";
connectAttr "polyExtrudeFace2.out" "polyTweak20.ip";
connectAttr "polyTweak21.out" "polySplitRing8.ip";
connectAttr "LockShellShape.wm" "polySplitRing8.mp";
connectAttr "polySplitRing7.out" "polyTweak21.ip";
connectAttr "polyTweak22.out" "polySplitRing9.ip";
connectAttr "LockShellShape.wm" "polySplitRing9.mp";
connectAttr "polySplitRing8.out" "polyTweak22.ip";
connectAttr "polySplitRing9.out" "polyTweak23.ip";
connectAttr "polyTweak23.out" "deleteComponent17.ig";
connectAttr "deleteComponent17.og" "polyBridgeEdge3.ip";
connectAttr "LockShellShape.wm" "polyBridgeEdge3.mp";
connectAttr "polyCube6.out" "polyBevel1.ip";
connectAttr "pCubeShape23.wm" "polyBevel1.mp";
connectAttr "polyBridgeEdge3.out" "polyBevel2.ip";
connectAttr "LockShellShape.wm" "polyBevel2.mp";
connectAttr "polyTweak24.out" "polyExtrudeFace3.ip";
connectAttr "LockHoleShape.wm" "polyExtrudeFace3.mp";
connectAttr "polyCylinder1.out" "polyTweak24.ip";
connectAttr "polyExtrudeFace3.out" "polyExtrudeFace4.ip";
connectAttr "LockHoleShape.wm" "polyExtrudeFace4.mp";
connectAttr "polyTweak25.out" "polyExtrudeFace5.ip";
connectAttr "LockHoleShape.wm" "polyExtrudeFace5.mp";
connectAttr "polyExtrudeFace4.out" "polyTweak25.ip";
connectAttr "polyTweak26.out" "polySoftEdge4.ip";
connectAttr "LockHoleShape.wm" "polySoftEdge4.mp";
connectAttr "polyExtrudeFace5.out" "polyTweak26.ip";
connectAttr "polyBevel1.out" "polyTweak27.ip";
connectAttr "polyTweak27.out" "polySplit23.ip";
connectAttr "polySplit23.out" "polySplit24.ip";
connectAttr "polySplit24.out" "polySplit25.ip";
connectAttr "polySplit25.out" "polySplit26.ip";
connectAttr "polyBevel2.out" "polyTweakUV3.ip";
connectAttr "polyTweak28.out" "polyMergeVert5.ip";
connectAttr "LockShellShape.wm" "polyMergeVert5.mp";
connectAttr "polyTweakUV3.out" "polyTweak28.ip";
connectAttr "polyMergeVert5.out" "polyTweakUV4.ip";
connectAttr "polyTweak29.out" "polyMergeVert6.ip";
connectAttr "LockShellShape.wm" "polyMergeVert6.mp";
connectAttr "polyTweakUV4.out" "polyTweak29.ip";
connectAttr "polyMergeVert6.out" "polyTweakUV5.ip";
connectAttr "polyTweak30.out" "polyMergeVert7.ip";
connectAttr "LockShellShape.wm" "polyMergeVert7.mp";
connectAttr "polyTweakUV5.out" "polyTweak30.ip";
connectAttr "polyMergeVert7.out" "polyTweakUV6.ip";
connectAttr "polyTweak31.out" "polyMergeVert8.ip";
connectAttr "LockShellShape.wm" "polyMergeVert8.mp";
connectAttr "polyTweakUV6.out" "polyTweak31.ip";
connectAttr "polyMergeVert8.out" "polySplit27.ip";
connectAttr "polySplit27.out" "polySplit28.ip";
connectAttr "polySplit28.out" "polyTweak32.ip";
connectAttr "polyTweak32.out" "polySplit29.ip";
connectAttr "polySplit29.out" "polySplit30.ip";
connectAttr "polySplit30.out" "polySplit31.ip";
connectAttr "polySplit31.out" "polySplit32.ip";
connectAttr "polySplit32.out" "polySplit33.ip";
connectAttr "polySplit33.out" "polySplit34.ip";
connectAttr "polySplit34.out" "polySplit35.ip";
connectAttr "polySplit35.out" "polySplit36.ip";
connectAttr "polySplit36.out" "polySplit37.ip";
connectAttr "polySplit37.out" "polySplit38.ip";
connectAttr "polySplit38.out" "polySplit39.ip";
connectAttr "polySplit39.out" "polySplit40.ip";
connectAttr "polySplit40.out" "polySplit41.ip";
connectAttr "polySplit41.out" "polySplit42.ip";
connectAttr "polySplit42.out" "polySplit43.ip";
connectAttr "polySplit43.out" "polySplit44.ip";
connectAttr "polySplit44.out" "polySplit45.ip";
connectAttr "polySplit45.out" "polySplit46.ip";
connectAttr "polySplit46.out" "polySplit47.ip";
connectAttr "polySplit47.out" "polySplit48.ip";
connectAttr "polySplit48.out" "polySplit49.ip";
connectAttr "polySplit49.out" "polySplit50.ip";
connectAttr "polySplit50.out" "polySplit51.ip";
connectAttr "polySplit51.out" "polySplit52.ip";
connectAttr "polySplit52.out" "polySplit53.ip";
connectAttr "polySplit53.out" "polyTweakUV7.ip";
connectAttr "polyTweak33.out" "polyMergeVert9.ip";
connectAttr "LockShellShape.wm" "polyMergeVert9.mp";
connectAttr "polyTweakUV7.out" "polyTweak33.ip";
connectAttr "polyMergeVert9.out" "polyTweakUV8.ip";
connectAttr "polyTweak34.out" "polyMergeVert10.ip";
connectAttr "LockShellShape.wm" "polyMergeVert10.mp";
connectAttr "polyTweakUV8.out" "polyTweak34.ip";
connectAttr "polyMergeVert10.out" "polySplit54.ip";
connectAttr "polySplit54.out" "polySplit55.ip";
connectAttr "polySplit55.out" "polySplit56.ip";
connectAttr "polySplit56.out" "polySplit57.ip";
connectAttr "polySplit57.out" "polySplit58.ip";
connectAttr "polySplit58.out" "polySplit59.ip";
connectAttr "polySplit59.out" "polySplitRing10.ip";
connectAttr "LockShellShape.wm" "polySplitRing10.mp";
connectAttr "polySplitRing10.out" "polySplit60.ip";
connectAttr "polySplit60.out" "deleteComponent18.ig";
connectAttr "deleteComponent18.og" "polyConnectComponents1.ip";
connectAttr "polyConnectComponents1.out" "polyTweak35.ip";
connectAttr "polyTweak35.out" "polySplit61.ip";
connectAttr "polySplit61.out" "polyTweak36.ip";
connectAttr "polyTweak36.out" "deleteComponent19.ig";
connectAttr "deleteComponent19.og" "deleteComponent20.ig";
connectAttr "deleteComponent20.og" "polyBridgeEdge4.ip";
connectAttr "LockShellShape.wm" "polyBridgeEdge4.mp";
connectAttr "polyBridgeEdge4.out" "polySplitRing11.ip";
connectAttr "LockShellShape.wm" "polySplitRing11.mp";
connectAttr "polySplitRing11.out" "polyTweak37.ip";
connectAttr "polyTweak37.out" "polySplit62.ip";
connectAttr "polyTweak38.out" "polyDelEdge6.ip";
connectAttr "polySplit62.out" "polyTweak38.ip";
connectAttr "polyDelEdge6.out" "polyDelEdge7.ip";
connectAttr "polyDelEdge7.out" "polySplit63.ip";
connectAttr "polySplit63.out" "polySplit64.ip";
connectAttr "polySplit64.out" "polyDelEdge8.ip";
connectAttr "polyDelEdge8.out" "polyExtrudeFace6.ip";
connectAttr "LockShellShape.wm" "polyExtrudeFace6.mp";
connectAttr "polyTweak39.out" "polyExtrudeFace7.ip";
connectAttr "LockShellShape.wm" "polyExtrudeFace7.mp";
connectAttr "polyExtrudeFace6.out" "polyTweak39.ip";
connectAttr "polyExtrudeFace7.out" "deleteComponent21.ig";
connectAttr "deleteComponent21.og" "polyCloseBorder2.ip";
connectAttr "polyCloseBorder2.out" "polySplit65.ip";
connectAttr "polySplit65.out" "polySplit66.ip";
connectAttr "polySplit66.out" "polyCloseBorder3.ip";
connectAttr "polyCloseBorder3.out" "polySplit67.ip";
connectAttr "polySplit67.out" "polySplit68.ip";
connectAttr "polySplit68.out" "polyDelEdge9.ip";
connectAttr "polyDelEdge9.out" "polyConnectComponents2.ip";
connectAttr "polyConnectComponents2.out" "polyDelEdge10.ip";
connectAttr "polyDelEdge10.out" "polyTweak40.ip";
connectAttr "polyTweak40.out" "polySplit69.ip";
connectAttr "polySplit69.out" "polyConnectComponents3.ip";
connectAttr "polyConnectComponents3.out" "polyDelEdge11.ip";
connectAttr "polyDelEdge11.out" "polyConnectComponents4.ip";
connectAttr "polyConnectComponents4.out" "polyConnectComponents5.ip";
connectAttr "polyConnectComponents5.out" "polyDelEdge12.ip";
connectAttr "polyDelEdge12.out" "polyDelEdge13.ip";
connectAttr "polyDelEdge13.out" "polyDelEdge14.ip";
connectAttr "polyDelEdge14.out" "polyConnectComponents6.ip";
connectAttr "polyConnectComponents6.out" "polyTweakUV9.ip";
connectAttr "polyTweak41.out" "polyMergeVert11.ip";
connectAttr "LockShellShape.wm" "polyMergeVert11.mp";
connectAttr "polyTweakUV9.out" "polyTweak41.ip";
connectAttr "polyMergeVert11.out" "polyDelEdge15.ip";
connectAttr "polyDelEdge15.out" "polyDelEdge16.ip";
connectAttr "polyDelEdge16.out" "polySplit70.ip";
connectAttr "polySplit70.out" "polyConnectComponents7.ip";
connectAttr "polyConnectComponents7.out" "polyTweakUV10.ip";
connectAttr "polyTweak42.out" "polyMergeVert12.ip";
connectAttr "LockShellShape.wm" "polyMergeVert12.mp";
connectAttr "polyTweakUV10.out" "polyTweak42.ip";
connectAttr "polyMergeVert12.out" "polyTweakUV11.ip";
connectAttr "polyTweak43.out" "polyMergeVert13.ip";
connectAttr "LockShellShape.wm" "polyMergeVert13.mp";
connectAttr "polyTweakUV11.out" "polyTweak43.ip";
connectAttr "polyMergeVert13.out" "polyDelEdge17.ip";
connectAttr "polyDelEdge17.out" "polyDelEdge18.ip";
connectAttr "polyDelEdge18.out" "polyConnectComponents8.ip";
connectAttr "polyConnectComponents8.out" "polySplit71.ip";
connectAttr "polySplit71.out" "polyTweakUV12.ip";
connectAttr "polyTweak44.out" "polyMergeVert14.ip";
connectAttr "LockShellShape.wm" "polyMergeVert14.mp";
connectAttr "polyTweakUV12.out" "polyTweak44.ip";
connectAttr "polyMergeVert14.out" "polyTweakUV13.ip";
connectAttr "polyTweak45.out" "polyMergeVert15.ip";
connectAttr "LockShellShape.wm" "polyMergeVert15.mp";
connectAttr "polyTweakUV13.out" "polyTweak45.ip";
connectAttr "polyMergeVert15.out" "polyDelEdge19.ip";
connectAttr "polyDelEdge19.out" "polySplit72.ip";
connectAttr "polySplit72.out" "polyConnectComponents9.ip";
connectAttr "polyConnectComponents9.out" "polyDelEdge20.ip";
connectAttr "polyDelEdge20.out" "polyDelEdge21.ip";
connectAttr "polyDelEdge21.out" "polyConnectComponents10.ip";
connectAttr "polyConnectComponents10.out" "polyConnectComponents11.ip";
connectAttr "polyConnectComponents11.out" "polySplit73.ip";
connectAttr "polySplit73.out" "polyDelEdge22.ip";
connectAttr "polyDelEdge22.out" "polyConnectComponents12.ip";
connectAttr "polyConnectComponents12.out" "polyTweakUV14.ip";
connectAttr "polyTweak46.out" "polyMergeVert16.ip";
connectAttr "LockShellShape.wm" "polyMergeVert16.mp";
connectAttr "polyTweakUV14.out" "polyTweak46.ip";
connectAttr "polyMergeVert16.out" "polyTweakUV15.ip";
connectAttr "polyTweak47.out" "polyMergeVert17.ip";
connectAttr "LockShellShape.wm" "polyMergeVert17.mp";
connectAttr "polyTweakUV15.out" "polyTweak47.ip";
connectAttr "polyMergeVert17.out" "polySplit74.ip";
connectAttr "polySplit74.out" "polyDelEdge23.ip";
connectAttr "polyDelEdge23.out" "polyConnectComponents13.ip";
connectAttr "polyConnectComponents13.out" "polyDelEdge24.ip";
connectAttr "polyDelEdge24.out" "polyDelEdge25.ip";
connectAttr "polyDelEdge25.out" "polyDelEdge26.ip";
connectAttr "polyDelEdge26.out" "polyConnectComponents14.ip";
connectAttr "polyConnectComponents14.out" "polySplit75.ip";
connectAttr "polySplit75.out" "polyTweakUV16.ip";
connectAttr "polyTweak48.out" "polyMergeVert18.ip";
connectAttr "LockShellShape.wm" "polyMergeVert18.mp";
connectAttr "polyTweakUV16.out" "polyTweak48.ip";
connectAttr "polyMergeVert18.out" "polyTweakUV17.ip";
connectAttr "polyTweak49.out" "polyMergeVert19.ip";
connectAttr "LockShellShape.wm" "polyMergeVert19.mp";
connectAttr "polyTweakUV17.out" "polyTweak49.ip";
connectAttr "polyMergeVert19.out" "polyTweakUV18.ip";
connectAttr "polyTweak50.out" "polyMergeVert20.ip";
connectAttr "LockShellShape.wm" "polyMergeVert20.mp";
connectAttr "polyTweakUV18.out" "polyTweak50.ip";
connectAttr "polyMergeVert20.out" "polyDelEdge27.ip";
connectAttr "polyDelEdge27.out" "polyTweakUV19.ip";
connectAttr "polyTweak51.out" "polyMergeVert21.ip";
connectAttr "LockShellShape.wm" "polyMergeVert21.mp";
connectAttr "polyTweakUV19.out" "polyTweak51.ip";
connectAttr "polyMergeVert21.out" "polyTweakUV20.ip";
connectAttr "polyTweak52.out" "polyMergeVert22.ip";
connectAttr "LockShellShape.wm" "polyMergeVert22.mp";
connectAttr "polyTweakUV20.out" "polyTweak52.ip";
connectAttr "polyMergeVert22.out" "polyDelEdge28.ip";
connectAttr "polyDelEdge28.out" "polyDelEdge29.ip";
connectAttr "polyDelEdge29.out" "polyDelEdge30.ip";
connectAttr "polyDelEdge30.out" "polyConnectComponents15.ip";
connectAttr "polyConnectComponents15.out" "polySplit76.ip";
connectAttr "polySplit76.out" "polyDelEdge31.ip";
connectAttr "polyDelEdge31.out" "polyConnectComponents16.ip";
connectAttr "polyConnectComponents16.out" "polyConnectComponents17.ip";
connectAttr "polyConnectComponents17.out" "polyConnectComponents18.ip";
connectAttr "polyConnectComponents18.out" "polyDelEdge32.ip";
connectAttr "polyDelEdge32.out" "polyConnectComponents19.ip";
connectAttr "polyConnectComponents19.out" "polyDelEdge33.ip";
connectAttr "polyDelEdge33.out" "polyDelEdge34.ip";
connectAttr "polyDelEdge34.out" "polyDelEdge35.ip";
connectAttr "polyDelEdge35.out" "polySplit77.ip";
connectAttr "polySplit77.out" "polyConnectComponents20.ip";
connectAttr "polyConnectComponents20.out" "polyConnectComponents21.ip";
connectAttr "polyConnectComponents21.out" "polyDelEdge36.ip";
connectAttr "polyDelEdge36.out" "polySplit78.ip";
connectAttr "polySplit78.out" "polySplit79.ip";
connectAttr "polySplit79.out" "polySplit80.ip";
connectAttr "polySplit80.out" "polyDelEdge37.ip";
connectAttr "polyDelEdge37.out" "polyDelEdge38.ip";
connectAttr "polyDelEdge38.out" "polyConnectComponents22.ip";
connectAttr "polyConnectComponents22.out" "polyDelEdge39.ip";
connectAttr "polyDelEdge39.out" "polyTweakUV21.ip";
connectAttr "polyTweak53.out" "polyMergeVert23.ip";
connectAttr "LockShellShape.wm" "polyMergeVert23.mp";
connectAttr "polyTweakUV21.out" "polyTweak53.ip";
connectAttr "polyMergeVert23.out" "polyTweakUV22.ip";
connectAttr "polyTweak54.out" "polyMergeVert24.ip";
connectAttr "LockShellShape.wm" "polyMergeVert24.mp";
connectAttr "polyTweakUV22.out" "polyTweak54.ip";
connectAttr "polyMergeVert24.out" "polySplit81.ip";
connectAttr "polySplit81.out" "polySplit82.ip";
connectAttr "polySplit82.out" "polyConnectComponents23.ip";
connectAttr "polyConnectComponents23.out" "polySplit83.ip";
connectAttr "polySplit83.out" "polyDelEdge40.ip";
connectAttr "polyDelEdge40.out" "polyConnectComponents24.ip";
connectAttr "polyConnectComponents24.out" "polyConnectComponents25.ip";
connectAttr "polyConnectComponents25.out" "polyDelEdge41.ip";
connectAttr "polyDelEdge41.out" "polyConnectComponents26.ip";
connectAttr "polyCube8.out" "polyDelEdge42.ip";
connectAttr "polyTweak55.out" "polySplitRing12.ip";
connectAttr "pCubeShape25.wm" "polySplitRing12.mp";
connectAttr "polyDelEdge42.out" "polyTweak55.ip";
connectAttr "polySplitRing12.out" "polyTweak56.ip";
connectAttr "polyTweak56.out" "deleteComponent22.ig";
connectAttr "deleteComponent22.og" "polyBridgeEdge5.ip";
connectAttr "pCubeShape25.wm" "polyBridgeEdge5.mp";
connectAttr "polyBridgeEdge5.out" "polyTweakUV23.ip";
connectAttr "polyTweak57.out" "polyMergeVert25.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert25.mp";
connectAttr "polyTweakUV23.out" "polyTweak57.ip";
connectAttr "polyMergeVert25.out" "polyTweakUV24.ip";
connectAttr "polyTweak58.out" "polyMergeVert26.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert26.mp";
connectAttr "polyTweakUV24.out" "polyTweak58.ip";
connectAttr "polyMergeVert26.out" "polyTweakUV25.ip";
connectAttr "polyTweak59.out" "polyMergeVert27.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert27.mp";
connectAttr "polyTweakUV25.out" "polyTweak59.ip";
connectAttr "polyMergeVert27.out" "polyTweakUV26.ip";
connectAttr "polyTweak60.out" "polyMergeVert28.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert28.mp";
connectAttr "polyTweakUV26.out" "polyTweak60.ip";
connectAttr "polyMergeVert28.out" "polyTweakUV27.ip";
connectAttr "polyTweak61.out" "polyMergeVert29.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert29.mp";
connectAttr "polyTweakUV27.out" "polyTweak61.ip";
connectAttr "polyMergeVert29.out" "polyTweakUV28.ip";
connectAttr "polyTweak62.out" "polyMergeVert30.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert30.mp";
connectAttr "polyTweakUV28.out" "polyTweak62.ip";
connectAttr "polyMergeVert30.out" "polyTweakUV29.ip";
connectAttr "polyTweak63.out" "polyMergeVert31.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert31.mp";
connectAttr "polyTweakUV29.out" "polyTweak63.ip";
connectAttr "polyMergeVert31.out" "polyTweakUV30.ip";
connectAttr "polyTweak64.out" "polyMergeVert32.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert32.mp";
connectAttr "polyTweakUV30.out" "polyTweak64.ip";
connectAttr "polyMergeVert32.out" "polyTweakUV31.ip";
connectAttr "polyTweak65.out" "polyMergeVert33.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert33.mp";
connectAttr "polyTweakUV31.out" "polyTweak65.ip";
connectAttr "polyMergeVert33.out" "polyTweakUV32.ip";
connectAttr "polyTweak66.out" "polyMergeVert34.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert34.mp";
connectAttr "polyTweakUV32.out" "polyTweak66.ip";
connectAttr "polyMergeVert34.out" "polyTweakUV33.ip";
connectAttr "polyTweak67.out" "polyMergeVert35.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert35.mp";
connectAttr "polyTweakUV33.out" "polyTweak67.ip";
connectAttr "polyMergeVert35.out" "polyTweakUV34.ip";
connectAttr "polyTweak68.out" "polyMergeVert36.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert36.mp";
connectAttr "polyTweakUV34.out" "polyTweak68.ip";
connectAttr "polyMergeVert36.out" "polyTweakUV35.ip";
connectAttr "polyTweak69.out" "polyMergeVert37.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert37.mp";
connectAttr "polyTweakUV35.out" "polyTweak69.ip";
connectAttr "polyMergeVert37.out" "polyTweakUV36.ip";
connectAttr "polyTweak70.out" "polyMergeVert38.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert38.mp";
connectAttr "polyTweakUV36.out" "polyTweak70.ip";
connectAttr "polyMergeVert38.out" "polyTweakUV37.ip";
connectAttr "polyTweak71.out" "polyMergeVert39.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert39.mp";
connectAttr "polyTweakUV37.out" "polyTweak71.ip";
connectAttr "polyMergeVert39.out" "polyTweakUV38.ip";
connectAttr "polyTweak72.out" "polyMergeVert40.ip";
connectAttr "pCubeShape25.wm" "polyMergeVert40.mp";
connectAttr "polyTweakUV38.out" "polyTweak72.ip";
connectAttr "polyCube9.out" "polyTweak73.ip";
connectAttr "polyTweak73.out" "deleteComponent23.ig";
connectAttr "deleteComponent23.og" "polyBridgeEdge6.ip";
connectAttr "pCubeShape26.wm" "polyBridgeEdge6.mp";
connectAttr "polyCube10.out" "polyExtrudeFace8.ip";
connectAttr "pCubeShape27.wm" "polyExtrudeFace8.mp";
connectAttr "polyTweak74.out" "polySplitRing13.ip";
connectAttr "pCubeShape27.wm" "polySplitRing13.mp";
connectAttr "polyExtrudeFace8.out" "polyTweak74.ip";
connectAttr "polyTweak75.out" "polySplitRing14.ip";
connectAttr "pCubeShape27.wm" "polySplitRing14.mp";
connectAttr "polySplitRing13.out" "polyTweak75.ip";
connectAttr "polyTweak76.out" "polyExtrudeFace9.ip";
connectAttr "pCubeShape27.wm" "polyExtrudeFace9.mp";
connectAttr "polySplitRing14.out" "polyTweak76.ip";
connectAttr "polyTweak77.out" "polySplitRing15.ip";
connectAttr "pCubeShape27.wm" "polySplitRing15.mp";
connectAttr "polyExtrudeFace9.out" "polyTweak77.ip";
connectAttr "polyTweak78.out" "polyDelEdge43.ip";
connectAttr "polySplitRing15.out" "polyTweak78.ip";
connectAttr "polyCube11.out" "polyExtrudeFace10.ip";
connectAttr "pCubeShape28.wm" "polyExtrudeFace10.mp";
connectAttr "polyTweak79.out" "polyExtrudeFace11.ip";
connectAttr "pCubeShape28.wm" "polyExtrudeFace11.mp";
connectAttr "polyExtrudeFace10.out" "polyTweak79.ip";
connectAttr "polyExtrudeFace11.out" "polyExtrudeFace12.ip";
connectAttr "pCubeShape28.wm" "polyExtrudeFace12.mp";
connectAttr "polyTweak80.out" "polyExtrudeFace13.ip";
connectAttr "pCubeShape28.wm" "polyExtrudeFace13.mp";
connectAttr "polyExtrudeFace12.out" "polyTweak80.ip";
connectAttr "polyTweak81.out" "polySplitRing16.ip";
connectAttr "pCubeShape28.wm" "polySplitRing16.mp";
connectAttr "polyExtrudeFace13.out" "polyTweak81.ip";
connectAttr "polyTweak82.out" "polyExtrudeFace14.ip";
connectAttr "pCubeShape28.wm" "polyExtrudeFace14.mp";
connectAttr "polySplitRing16.out" "polyTweak82.ip";
connectAttr "polyTweak83.out" "polyMergeVert41.ip";
connectAttr "pCubeShape28.wm" "polyMergeVert41.mp";
connectAttr "polyExtrudeFace14.out" "polyTweak83.ip";
connectAttr "polyCube12.out" "deleteComponent24.ig";
connectAttr "deleteComponent24.og" "deleteComponent25.ig";
connectAttr "deleteComponent25.og" "polyDelEdge44.ip";
connectAttr "polyDelEdge44.out" "polyBridgeEdge7.ip";
connectAttr "pCubeShape29.wm" "polyBridgeEdge7.mp";
connectAttr "polyBridgeEdge7.out" "polyBridgeEdge8.ip";
connectAttr "pCubeShape29.wm" "polyBridgeEdge8.mp";
connectAttr "polyBridgeEdge8.out" "polyBridgeEdge9.ip";
connectAttr "pCubeShape29.wm" "polyBridgeEdge9.mp";
connectAttr "polyBridgeEdge9.out" "polyBridgeEdge10.ip";
connectAttr "pCubeShape29.wm" "polyBridgeEdge10.mp";
connectAttr "polyBridgeEdge10.out" "polyDelEdge45.ip";
connectAttr "polyDelEdge45.out" "polyDelEdge46.ip";
connectAttr "polyDelEdge46.out" "polyDelEdge47.ip";
connectAttr "polyDelEdge47.out" "polyDelEdge48.ip";
connectAttr "polyDelEdge48.out" "polySplit84.ip";
connectAttr "polySplit84.out" "polySplit85.ip";
connectAttr "polySplit85.out" "polySplit86.ip";
connectAttr "polySplit86.out" "polySplit87.ip";
connectAttr "polyTweak84.out" "polySplitRing17.ip";
connectAttr "pCubeShape27.wm" "polySplitRing17.mp";
connectAttr "polyDelEdge43.out" "polyTweak84.ip";
connectAttr "polySplitRing17.out" "polyDelEdge49.ip";
connectAttr "polyTweak85.out" "polySplitRing18.ip";
connectAttr "pCubeShape30.wm" "polySplitRing18.mp";
connectAttr "polyCube13.out" "polyTweak85.ip";
connectAttr "polySurfaceShape1.o" "polyBridgeEdge11.ip";
connectAttr "pCubeShape34.wm" "polyBridgeEdge11.mp";
connectAttr "polyTweak86.out" "polyDelEdge50.ip";
connectAttr "polyDelEdge49.out" "polyTweak86.ip";
connectAttr "polyDelEdge50.out" "polySplit88.ip";
connectAttr "polySplit88.out" "polySplit89.ip";
connectAttr "polySplit89.out" "polyDelEdge51.ip";
connectAttr "polyDelEdge51.out" "polySplit90.ip";
connectAttr "polySplit90.out" "polySplit91.ip";
connectAttr "polySplit91.out" "polySplit92.ip";
connectAttr "polySplit92.out" "polySplit93.ip";
connectAttr "polySplit93.out" "polyMergeVert42.ip";
connectAttr "pCubeShape27.wm" "polyMergeVert42.mp";
connectAttr "polyTweak87.out" "polySplitRing19.ip";
connectAttr "pCubeShape27.wm" "polySplitRing19.mp";
connectAttr "polyMergeVert42.out" "polyTweak87.ip";
connectAttr "polySplitRing19.out" "polyDelEdge52.ip";
connectAttr "lambert2SG.pa" ":renderPartition.st" -na;
connectAttr "lambert3SG.pa" ":renderPartition.st" -na;
connectAttr "lambert4SG.pa" ":renderPartition.st" -na;
connectAttr "bifrostLiquidMaterial1SG.pa" ":renderPartition.st" -na;
connectAttr "blinn1SG.pa" ":renderPartition.st" -na;
connectAttr "anisotropic1SG.pa" ":renderPartition.st" -na;
connectAttr "ShaderfxGameHair1SG.pa" ":renderPartition.st" -na;
connectAttr "lambert5SG.pa" ":renderPartition.st" -na;
connectAttr "BoatSG.pa" ":renderPartition.st" -na;
connectAttr "Coach1SG.pa" ":renderPartition.st" -na;
connectAttr "BackShellSG.pa" ":renderPartition.st" -na;
connectAttr "Platform1SG.pa" ":renderPartition.st" -na;
connectAttr "PlatformDecoSG.pa" ":renderPartition.st" -na;
connectAttr "Left_EarSG.pa" ":renderPartition.st" -na;
connectAttr "Platform1SG1.pa" ":renderPartition.st" -na;
connectAttr "PlatformDecoSG1.pa" ":renderPartition.st" -na;
connectAttr "Left_EarSG1.pa" ":renderPartition.st" -na;
connectAttr "lambert6SG.pa" ":renderPartition.st" -na;
connectAttr "InnerMat.msg" ":defaultShaderList1.s" -na;
connectAttr "CutoutMat.msg" ":defaultShaderList1.s" -na;
connectAttr "OutterMat.msg" ":defaultShaderList1.s" -na;
connectAttr "Water.msg" ":defaultShaderList1.s" -na;
connectAttr "place2dTexture1.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "place2dTexture2.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "place2dTexture3.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "place2dTexture4.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "place2dTexture5.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "place2dTexture6.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "place2dTexture7.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "file1.msg" ":defaultTextureList1.tx" -na;
connectAttr "bulge1.msg" ":defaultTextureList1.tx" -na;
connectAttr "file2.msg" ":defaultTextureList1.tx" -na;
connectAttr "file3.msg" ":defaultTextureList1.tx" -na;
connectAttr "file4.msg" ":defaultTextureList1.tx" -na;
connectAttr "file5.msg" ":defaultTextureList1.tx" -na;
connectAttr "file6.msg" ":defaultTextureList1.tx" -na;
connectAttr "UVPlaneShape.iog" ":initialShadingGroup.dsm" -na;
connectAttr "PaperCraneShape.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape22.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape23.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape24.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape25.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape26.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape27.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape28.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pSphereShape1.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape29.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape30.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape31.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape32.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape33.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape34.iog" ":initialShadingGroup.dsm" -na;
connectAttr "LadderShape.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "groupId80.msg" ":initialShadingGroup.gn" -na;
connectAttr "Platform2HandleShapeHiddenFacesSet.msg" ":defaultHideFaceDataSet.dnsm"
		 -na;
connectAttr "Platform2HandleShapeHiddenFacesSet1.msg" ":defaultHideFaceDataSet.dnsm"
		 -na;
// End of Level0.ma
